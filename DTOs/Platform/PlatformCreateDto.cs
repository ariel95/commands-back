using System.ComponentModel.DataAnnotations;

namespace Commands.DTOs
{
    public class PlatformCreateDto
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(255)]
        public string Description { get; set; }
    }
}