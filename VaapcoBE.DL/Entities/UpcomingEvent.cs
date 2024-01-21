using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VaapcoBE.DL.Entities
{
    public class UpcomingEvent
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EId {  get; set; }
        public string EventTitile { get; set; }
        public string EventVenue { get; set; }
        public DateTime EventDate { get; set; }
        public DateTime EventAddDate { get; set; }
        public DateTime EventModifyDate { get; set;}
        public string EventLink {  get; set; }

    }
}
