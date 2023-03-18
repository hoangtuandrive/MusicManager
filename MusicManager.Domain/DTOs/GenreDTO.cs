using System.ComponentModel.DataAnnotations;

namespace MusicManager.Domain.DTOs
{
    public class GenreDTO
    {
        [Required]
        public string Name { get; set; }
    }
}
