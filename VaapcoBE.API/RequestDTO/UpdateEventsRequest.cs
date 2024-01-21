namespace VaapcoBE.API.RequestDTO
{
    public class UpdateEventsRequest
    {
        public int EId { get; set; }
        public string EventTitile { get; set; }
        public string EventVenue { get; set; }
        public DateTime EventDate { get; set; }
        public string EventLink { get; set; }
    }
}
