using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VaapcoBE.BL.DTO
{
    public class GetEventsDTO
    {
        public string EventTitile { get; set; }
        public string EventVenue { get; set; }
        public DateTime EventDate { get; set; }
        public DateTime EventAddDate { get; set; }
        public DateTime EventModifyDate { get; set; }
        public string EventLink { get; set; }
    }
}
