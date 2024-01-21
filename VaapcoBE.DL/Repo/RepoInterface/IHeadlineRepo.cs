using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VaapcoBE.DL.Entities;
using static System.Reflection.Metadata.BlobBuilder;

namespace VaapcoBE.DL.Repo.RepoInterface
{
    public interface IHeadlineRepo
    {
        public Task<bool> AddHeadline(NewsHeadline Headline);
        public List<NewsHeadline> GetHeadlines();
        public Task<bool> UpdateHeadline(NewsHeadline updateHeadline);
        public bool DeleteHeadlines(int HId);
    }
}
