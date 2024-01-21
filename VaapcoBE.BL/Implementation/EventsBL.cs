using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using VaapcoBE.BL.DTO;
using VaapcoBE.BL.Interface;
using VaapcoBE.DL.Entities;
using VaapcoBE.DL.Repo.RepoImplementaion;
using VaapcoBE.DL.Repo.RepoInterface;

namespace VaapcoBE.BL.Implementation
{
    public class EventsBL : IEventsBL
    {
        private readonly IEventsRepo _eventRepo;

        public EventsBL(IEventsRepo Erepo)
        {
            _eventRepo = Erepo;
        }

        public async Task<bool> AddEvents(AddEventsDTO events)
        {
            var eventsEntity = new UpcomingEvent
            {
                EventTitile = events.EventTitile,
                EventVenue = events.EventVenue,
                EventDate= events.EventDate,
                EventAddDate = events.EventAddDate,
                EventModifyDate = events.EventModifyDate,
                EventLink = events.EventLink
            };
            return await _eventRepo.AddEvents(eventsEntity);
        }

        public bool DeleteEvent(int EId)
        {
            return _eventRepo.DeleteEvent(EId);
        }

        public List<GetEventsDTO> GetEvents()
        {
            var getEvents = _eventRepo.GetEvents();
            var list = new List<GetEventsDTO>();
            foreach (var item in getEvents)
            {
                list.Add(new GetEventsDTO
                {
                    EventTitile= item.EventTitile,
                    EventVenue= item.EventVenue,
                    EventDate = item.EventDate,
                    EventAddDate= item.EventAddDate,
                    EventModifyDate = item.EventModifyDate,
                    EventLink = item.EventLink
                });
            }
            return list;
        }

        public async Task<bool> UpdateEvents(UpdateEventsDTO updateEvent)
        {
            if (updateEvent != null)
            {
                var updatedEventsEntity = new UpcomingEvent
                {
                    EId = updateEvent.EId, 
                    EventTitile = updateEvent.EventTitile,
                    EventVenue = updateEvent.EventVenue,
                    EventDate = updateEvent.EventDate,
                    EventLink = updateEvent.EventLink
                };
                return await _eventRepo.UpdateEvents(updatedEventsEntity);
            }
            return false;
        }
    }
}
