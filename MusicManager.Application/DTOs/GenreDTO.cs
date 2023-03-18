using System.ComponentModel.DataAnnotations;

namespace MusicManager.Application.DTOs
{
    public class GenreDTO
    {
        [Required]
        public string Name { get; set; }
    }
}
