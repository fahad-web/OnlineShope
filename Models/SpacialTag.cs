using System.ComponentModel.DataAnnotations;

namespace OnlineShope.Models
{
    public class SpacialTag
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Condition")]
        public string? Condition { get; set; }
    }
}
