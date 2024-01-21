using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using VaapcoBE.DL.Entities;
using VaapcoBE.DL.Migrations;
using VaapcoBE.DL.Repo.RepoInterface;

namespace VaapcoBE.DL.Repo.RepoImplementaion
{
    public class EventsRepo : IEventsRepo
    {
        private readonly AppDbContext _appDbContext;
        public EventsRepo(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<bool> AddEvents(UpcomingEvent events)
        {
            _appDbContext.UpcomingEvents.Add(events);
            var result = await _appDbContext.SaveChangesAsync();
            if (result == 1)
                return true;
            return false;
        }

        public bool DeleteEvent(int EId)
        {
            var events = _appDbContext.UpcomingEvents.FirstOrDefault(x => x.EId == EId);
            if (events != null)
            {
                var status = _appDbContext.UpcomingEvents.Remove(events);
                if (status != null)
                {
                    _appDbContext.SaveChanges();
                    return true;
                }
            }
            return false;
        }

        public List<UpcomingEvent> GetEvents()
        {
            return _appDbContext.UpcomingEvents.ToList();
        }

        public async Task<bool> UpdateEvents(UpcomingEvent updateEvent)
        {
            var updateEntity = _appDbContext.UpcomingEvents.FirstOrDefault(x => x.EId == updateEvent.EId);
            if (updateEntity != null)
            {
                updateEntity.EventTitile = updateEvent.EventTitile;
                updateEntity.EventVenue = updateEvent.EventVenue;
                updateEntity.EventLink = updateEvent.EventLink;
                updateEntity.EventDate = updateEvent.EventDate;
                updateEntity.EventModifyDate = DateTime.Now;
                await _appDbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
