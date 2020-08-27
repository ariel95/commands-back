using System.ComponentModel.DataAnnotations;

namespace Commands.DTOs
{
    public class PlatformReadDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }    
}