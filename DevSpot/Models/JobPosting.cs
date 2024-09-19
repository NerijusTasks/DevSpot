using System.ComponentModel.DataAnnotations;

namespace DevSpot.Models
{
    public class JobPosting
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Descriptio { get; set; }
        [Required]
        public string Company { get; set; }
        [Required]
        public string Location { get; set; }
        public DateTime PostedDate { get; set; } = DateTime.UtcNow;
        public bool IsApproved { get; set; }
        public string UserId { get; set; }
    }
}
