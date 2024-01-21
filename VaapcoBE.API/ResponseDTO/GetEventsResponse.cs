namespace VaapcoBE.API.ResponseDTO
{
    public class GetEventsResponse
    {
        public string EventTitile { get; set; }
        public string EventVenue { get; set; }
        public DateTime EventDate { get; set; }
        public DateTime EventAddDate { get; set; }
        public DateTime EventModifyDate { get; set; }
        public string EventLink { get; set; }
    }
}
