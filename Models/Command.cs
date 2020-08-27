using System.ComponentModel.DataAnnotations;

namespace Commands.Models
{
    public class Command {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(255)]
        public string HowTo { get; set; }
        [Required]
        [MaxLength(255)]
        public string Line { get; set; }
        [MaxLength(100)]
        public string Platform { get; set; }
    }
    
}