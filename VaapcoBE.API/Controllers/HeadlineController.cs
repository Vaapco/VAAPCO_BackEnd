using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VaapcoBE.API.RequestDTO;
using VaapcoBE.API.ResponseDTO;
using VaapcoBE.BL.DTO;
using VaapcoBE.BL.Interface;

namespace VaapcoBE.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HeadlineController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IHeadlines _headlines;

        public HeadlineController(IMapper mapper, IHeadlines headlines)
        {
            _mapper = mapper;
            _headlines = headlines;
        }

        /// <summary>
        /// API to add new headline
        /// </summary>
        /// <param name="headLineRequest"></param>
        /// <returns></returns>
        [Authorize]
        [HttpPost("AddHeadline")]
        public async Task<ActionResult> AddHeadline([FromBody] AddHeadlineRequest headLineRequest)
        {
            var headline = _mapper.Map<NewsHeadlineDTO>(headLineRequest);
            var addHeadline = await _headlines.AddHeadlines(headline);
            if (addHeadline)
            {
                return StatusCode(StatusCodes.Status201Created);
            }
            else
            {
                return BadRequest("Error while adding new headline");
            }
        }

        ///<summary>
        ///API to get all headlines
        ///</summary>
        /// <returns></returns>
        [HttpGet("GetAllHeadlines")]
        public ActionResult<List<GetHeadlinesResponse>> GetAllHeadlines()
        {
            var headlines = _headlines.GetHeadlines();
            return _mapper.Map<List<GetHeadlinesResponse>>(headlines);
        }

        /// <summary>
        /// API to update the headline
        /// </summary>
        /// <param name="updateheadline"></param>
        /// <returns></returns>
        [Authorize]
        [HttpPut("UpdateHeadline")]
        public async Task<IActionResult> UpdateHeadline([FromBody] UpdateHeadlineRequest updateheadline)
        {
            var update_headline = _mapper.Map<UpdateHeadlineDTO>(updateheadline);   
            var status = await _headlines.UpdateHeadlines(update_headline);
            if (status)
            {
                return StatusCode(StatusCodes.Status200OK, "Updated Headline Successfully");
            }
            else
            {
                return BadRequest("Error while updating the headline");
            }
        }

        /// <summary>
        /// API to delete the headline
        /// </summary>
        /// <param name="HId"></param>
        /// <returns></returns>
        [Authorize]
        [HttpDelete("DeleteHeadline")]
        public IActionResult DeleteHeadline(int HId)
        {
            var status = _headlines.DeleteHeadlines(HId);
            if (status)
            {
                return StatusCode(StatusCodes.Status200OK, "Deleted the headline successfully!");
            }
            else
            {
                return StatusCode(StatusCodes.Status404NotFound, "Headline could not be found!");
            }
        }
    }
}
