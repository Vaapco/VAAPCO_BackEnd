using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VaapcoBE.BL.DTO;
using VaapcoBE.BL.Interface;
using VaapcoBE.DL;
using VaapcoBE.DL.Entities;
using VaapcoBE.DL.Repo.RepoInterface;

namespace VaapcoBE.BL.Implementation
{
    public class Headline : IHeadlines
    {
        private readonly IHeadlineRepo _headlineRepo;
        public Headline(IHeadlineRepo headlinerepo)
        {
            _headlineRepo = headlinerepo;
        }

        public async Task<bool> AddHeadlines(NewsHeadlineDTO headline)
        {
            var headlineEntity = new NewsHeadline
            {
                Headline = headline.Headline,
                HeadlineLink = headline.Headline,
                Date_Posted = headline.Date_Posted,
                Date_Updated = headline.Date_Updated
            };
            return await _headlineRepo.AddHeadline(headlineEntity);
        }

        public bool DeleteHeadlines(int HId)
        {
            return _headlineRepo.DeleteHeadlines(HId);
        }

        public List<GetHeadlinesDTO> GetHeadlines()
        {
            var get_headlines = _headlineRepo.GetHeadlines();
            var list = new List<GetHeadlinesDTO>();
            foreach(var item in get_headlines)
            {
                list.Add(new GetHeadlinesDTO
                {
                    Headline = item.Headline,
                    Date_Posted = item.Date_Posted,
                    Date_Updated = item.Date_Updated,
                    HeadlineLink = item.HeadlineLink
                });
            }
            return list;
        }

        public async Task<bool> UpdateHeadlines(UpdateHeadlineDTO updateHeadline)
        {
            if (updateHeadline != null)
            {
                var updatedHeadlineEntity = new NewsHeadline
                {
                    HId = updateHeadline.HId,
                    Headline = updateHeadline.Headline,
                    HeadlineLink = updateHeadline.HeadlineLink
                };
                return await _headlineRepo.UpdateHeadline(updatedHeadlineEntity);

            }
            return false;
        }
    }
}
