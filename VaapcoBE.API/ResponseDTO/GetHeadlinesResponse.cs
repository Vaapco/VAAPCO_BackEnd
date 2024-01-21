namespace VaapcoBE.API.ResponseDTO
{
    public class GetHeadlinesResponse
    {
        public string Headline { get; set; }
        public string HeadlineLink { get; set; }
        public DateTime Date_Posted { get; set; }
        public DateTime Date_Updated { get; set; }
    }
}
