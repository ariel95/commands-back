using System.ComponentModel.DataAnnotations;

namespace Commands.DTOs
{
    public class CommandReadDto {
        public int Id { get; set; }
        public string HowTo { get; set; }
        public string Line { get; set; }
        public int PlatformId { get; set; }
        public string PlatformName { get; set; }
    }
    
}