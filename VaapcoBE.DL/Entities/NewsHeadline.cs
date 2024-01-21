using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace VaapcoBE.DL.Entities
{
    public class NewsHeadline
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int HId { get; set; }
        public string Headline { get; set; }
        public string HeadlineLink { get; set; }
        public DateTime Date_Posted { get; set; }
        public DateTime Date_Updated { get; set; }

    }
}
