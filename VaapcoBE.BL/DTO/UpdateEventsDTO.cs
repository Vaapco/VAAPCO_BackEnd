using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VaapcoBE.BL.DTO
{
    public class UpdateEventsDTO
    {
        public int EId { get; set; }
        public string EventTitile { get; set; }
        public string EventVenue { get; set; }
        public DateTime EventDate { get; set; }
        public string EventLink { get; set; }
    }
}
