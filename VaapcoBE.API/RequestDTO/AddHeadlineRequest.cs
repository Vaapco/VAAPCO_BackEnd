using System.ComponentModel.DataAnnotations;

namespace VaapcoBE.API.RequestDTO
{
    public class AddHeadlineRequest
    {
        [Required]
        public string? Headline { get; set; }
        [Required]
        public string? HeadlineLink { get; set; }
        [Required]
        public DateTime Date_Posted { get; set; }
        public DateTime Date_Updated { get; set; }
    }
}
