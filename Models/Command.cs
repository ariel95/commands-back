using System.ComponentModel.DataAnnotations;

namespace Commands.Models
{
    public class Command
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(255)]
        public string HowTo { get; set; }
        [Required]
        [MaxLength(255)]
        public string Line { get; set; }
        [Required]
        public int PlatformId { get; set; }
        public Platform Platform { get; set; }
    }

}