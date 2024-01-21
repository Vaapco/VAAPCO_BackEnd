using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VaapcoBE.BL.DTO;

namespace VaapcoBE.BL.Interface
{
    public interface IHeadlines
    {
        public Task<bool> AddHeadlines(NewsHeadlineDTO headline);
        public List<GetHeadlinesDTO> GetHeadlines();
        public Task<bool> UpdateHeadlines(UpdateHeadlineDTO updateHeadline);
        public bool DeleteHeadlines(int HId);
    }
}
