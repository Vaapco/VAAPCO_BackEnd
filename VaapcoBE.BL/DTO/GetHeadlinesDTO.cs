using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VaapcoBE.BL.DTO
{
    public class GetHeadlinesDTO
    {
        public string Headline { get; set; }
        public string HeadlineLink { get; set; }
        public DateTime Date_Posted { get; set; }
        public DateTime Date_Updated { get; set; }
    }
}
