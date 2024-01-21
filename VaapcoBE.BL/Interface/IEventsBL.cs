using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VaapcoBE.BL.DTO;

namespace VaapcoBE.BL.Interface
{
    public interface IEventsBL
    {
        public Task<bool> AddEvents(AddEventsDTO events);
        public List<GetEventsDTO> GetEvents();
        public Task<bool> UpdateEvents(UpdateEventsDTO updateEvent);
        public bool DeleteEvent(int EId);
    }
}
