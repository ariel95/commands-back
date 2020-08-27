using System.ComponentModel.DataAnnotations;

namespace Commands.DTOs
{
    public class CommandCreateDto
    {
        [Required]
        [MaxLength(255)]
        public string HowTo { get; set; }
        [Required]
        [MaxLength(255)]
        public string Line { get; set; }
        [Required]
        public int PlatformId { get; set; }
    }

}