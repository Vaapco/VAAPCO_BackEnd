using System.ComponentModel.DataAnnotations;

namespace VaapcoBE.API.RequestDTO
{
    public class UpdateHeadlineRequest
    {
        public int HId { get; set; }
        [Required]
        public string? Headline { get; set; }
        [Required]
        public string? HeadlineLink { get; set; }
    }
}
