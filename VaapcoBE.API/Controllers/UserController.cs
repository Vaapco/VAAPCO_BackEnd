using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using VaapcoBE.API.Auth;
using VaapcoBE.API.RequestDTO;
using VaapcoBE.API.ResponseDTO;
using VaapcoBE.BL.DTO;
using VaapcoBE.BL.Interface;

namespace VaapcoBE.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserManagementService _userManager;
        private readonly IOptions<JwtConfig> _config;
        private readonly IMapper _mapper;

        public UserController(IUserManagementService userManager, ILogger<UserController> logger, IOptions<JwtConfig> config, IMapper mapper)
        {
            _userManager = userManager;
            _logger = logger;
            _config = config;
            _mapper = mapper;
        }

        /// <summary>
        /// API to add a new user
        /// </summary>
        /// <param name="data">Enter details of new user</param>
        /// <returns></returns>
        [HttpPost("RegisterUser")]
        public async Task<IActionResult> RegisterUser([FromBody] RegisterUserRequest data)
        {
            try
            {
                var entityUser = _mapper.Map<RegisterUserBL>(data);
                var status = await _userManager.RegisterUser(entityUser);
                _logger.LogDebug("User Db contacted successfully");
                if (status.Item1) // Register user success
                {
                    _logger.LogDebug($"User {data.EmailId} created  successfully");
                    var res = new ResponseCustom();
                    res.Message.Add("User Created Succesfully");
                    return Ok(res);
                }
                else
                {
                    var res = new ResponseCustom
                    {
                        Message = status.Item2
                    };
                    return BadRequest(res);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        /// <summary>
        /// API for User Login
        /// </summary>
        /// <param name="loginDTO">Enter Login details</param>
        /// <returns></returns>
        [HttpPost("LoginUser")]
        public async Task<IActionResult> LoginUser([FromBody] LoginUser loginDTO)
        {
            var loginStatus = await _userManager.LoginUser(loginDTO.Email, loginDTO.Password);
            if (loginStatus)
            {
                var res = GenerateJWt(loginDTO.Email).Result;
                return Ok(res);
            }
            else
            {
                return StatusCode(StatusCodes.Status406NotAcceptable, "Invalid Email-Id or Password!!\nTry Again!!");
            }
        }

        private async Task<LoginResponse> GenerateJWt(string email)
        {
            var authClaims = new List<Claim>
            {
                new Claim(ClaimTypes.Email,email)
            };

            var userRoles = await _userManager.GetRoles(email);
            foreach (var role in userRoles)
            {
                authClaims.Add(new Claim(ClaimTypes.Role, role));
            }
            // Form the security key
            var secKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.Value.Secret));
            var token = new JwtSecurityToken(
                issuer: _config.Value.ValidIssuer,
                audience: _config.Value.ValidAudience,
                expires: DateTime.Now.AddMinutes(30),
                claims: authClaims,
                signingCredentials: new SigningCredentials(secKey, SecurityAlgorithms.HmacSha256)
                );
            var jwtToken = new JwtSecurityTokenHandler().WriteToken(token);
            var expiry = token.ValidTo;
            return new LoginResponse
            {
                Token = jwtToken,
                Expiry = expiry
            };
        }

    }
}
