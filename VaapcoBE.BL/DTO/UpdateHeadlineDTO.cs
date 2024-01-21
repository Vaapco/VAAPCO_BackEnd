using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VaapcoBE.BL.DTO
{
    public class UpdateHeadlineDTO
    {
        public int HId {  get; set; }
        public string Headline { get; set; }
        public string HeadlineLink { get; set; }
    }
}
