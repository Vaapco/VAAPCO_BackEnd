using VaapcoBE.DL.Entities;
using VaapcoBE.DL.Repo.RepoInterface;

namespace VaapcoBE.DL.Repo.RepoImplementaion
{
    public class HeadlineRepo : IHeadlineRepo
    {
        private readonly AppDbContext _appDbContext;
        public HeadlineRepo(AppDbContext dBContext)
        {
            _appDbContext = dBContext;
        }

        public async Task<bool> AddHeadline(NewsHeadline headline)
        {
            _appDbContext.NewsHeadlines.Add(headline);
            var result = await _appDbContext.SaveChangesAsync();
            if (result == 1)
                return true;
            return false;
        }

        public bool DeleteHeadlines(int HId)
        {
            var headline = _appDbContext.NewsHeadlines.FirstOrDefault(x => x.HId == HId);
            if(headline != null)
            {
                var status = _appDbContext.NewsHeadlines.Remove(headline);
                if (status != null)
                {
                    _appDbContext.SaveChanges();
                    return true;
                }
            }
            return false;
        }

        public List<NewsHeadline> GetHeadlines()
        {
           return _appDbContext.NewsHeadlines.ToList();
        }

        public async Task<bool> UpdateHeadline(NewsHeadline updateHeadline)
        {
            var updateEntity = _appDbContext.NewsHeadlines.FirstOrDefault(x => x.HId == updateHeadline.HId);
            if (updateEntity != null)
            {
                updateEntity.Headline = updateHeadline.Headline;
                updateEntity.Date_Updated = DateTime.Now;
                updateEntity.HeadlineLink = updateHeadline.HeadlineLink;
                await _appDbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
