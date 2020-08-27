using System.ComponentModel.DataAnnotations;

namespace Commands.Models
{
    public class Platform
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(255)]
        public string Description { get; set; }
    }    
}