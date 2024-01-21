using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VaapcoBE.API.RequestDTO;
using VaapcoBE.API.ResponseDTO;
using VaapcoBE.BL.DTO;
using VaapcoBE.BL.Implementation;
using VaapcoBE.BL.Interface;

namespace VaapcoBE.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventsController:ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IEventsBL _events;

        public EventsController(IMapper mapper, IEventsBL events)
        {
            _mapper = mapper;
            _events = events;
        }

        /// <summary>
        /// API to add upcoming events
        /// </summary>
        /// <param name="eventRequest"></param>
        /// <returns></returns>
        [Authorize]
        [HttpPost("AddEvents")]
        public async Task<ActionResult> AddEvents([FromBody] AddEventsRequest eventRequest)
        {
            var events = _mapper.Map<AddEventsDTO>(eventRequest);
            var addEvents = await _events.AddEvents(events);
            if (addEvents)
            {
                return StatusCode(StatusCodes.Status201Created);
            }
            else
            {
                return BadRequest("Error while adding new events");
            }
        }

        ///<summary>
        ///API to get the events list
        ///</summary>
        /// <returns></returns>
        [HttpGet("GetAllEvents")]
        public ActionResult<List<GetEventsResponse>> GetAllEvents()
        {
            var events = _events.GetEvents();
            return _mapper.Map<List<GetEventsResponse>>(events);
        }

        /// <summary>
        /// API to update the event
        /// </summary>
        /// <param name="updateEvent"></param>
        /// <returns></returns>
        [Authorize]
        [HttpPut("UpdateEvent")]
        public async Task<IActionResult> UpdateEvent([FromBody] UpdateEventsRequest updateEvent)
        {
            var update_event = _mapper.Map<UpdateEventsDTO>(updateEvent);
            var status = await _events.UpdateEvents(update_event);
            if (status)
            {
                return StatusCode(StatusCodes.Status200OK, "Updated Event Successfully");
            }
            else
            {
                return BadRequest("Error while updating the Event");
            }
        }

        /// <summary>
        /// API to delete the event
        /// </summary>
        /// <param name="EId"></param>
        /// <returns></returns>
        [Authorize]
        [HttpDelete("DeleteEvent")]
        public IActionResult DeleteEvent(int EId)
        {
            var status = _events.DeleteEvent(EId);
            if (status)
            {
                return StatusCode(StatusCodes.Status200OK, "Deleted the event successfully!");
            }
            else
            {
                return StatusCode(StatusCodes.Status404NotFound, "Event could not be found!");
            }
        }
    }
}
