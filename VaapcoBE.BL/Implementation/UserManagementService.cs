using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VaapcoBE.BL.Constants;
using VaapcoBE.BL.DTO;
using VaapcoBE.BL.Interface;
using VaapcoBE.DL.Entities;

namespace VaapcoBE.BL.Implementation
{
    public class UserManagementService : IUserManagementService
    {
        private readonly UserManager<VaapcoUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UserManagementService(UserManager<VaapcoUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public async Task<Tuple<bool, List<string>>> RegisterUser(RegisterUserBL userDetails, bool isAdmin = false)
        {
            var errors = new List<string>();
            var userDL = new VaapcoUser
            {
                Email = userDetails.EmailId,
                UserName = userDetails.EmailId
            };
            var result = await _userManager.CreateAsync(userDL, userDetails.Password);
            if (result.Succeeded)
            {
                if (!await _roleManager.RoleExistsAsync(UserRoles.Admin))
                {
                    await _roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
                }
                if (isAdmin)
                {
                    await _userManager.AddToRoleAsync(userDL, UserRoles.Admin);
                }
                return Tuple.Create(true, new List<string>());
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    errors.Add($"{error.Code}-{error.Description}");
                }
                return Tuple.Create(false, errors);
            }
        }

        public async Task<IList<string>> GetRoles(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            var userRoles = await _userManager.GetRolesAsync(user);
            return userRoles;
        }

        public async Task<bool> LoginUser(string email, string password)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user != null)
            {
                var loginStatus = await _userManager.CheckPasswordAsync(user, password);
                return loginStatus;
            }
            return false;
        }
    }
}
