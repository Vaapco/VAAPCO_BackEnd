using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VaapcoBE.DL.Entities;

namespace VaapcoBE.DL.Repo.RepoInterface
{
    public interface IEventsRepo
    {
        public Task<bool> AddEvents(UpcomingEvent events);
        public List<UpcomingEvent> GetEvents();
        public Task<bool> UpdateEvents(UpcomingEvent updateEvent);
        public bool DeleteEvent(int EId);
    }
}
