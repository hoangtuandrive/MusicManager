using System.ComponentModel.DataAnnotations;

namespace MusicManager.API.DTOs
{
    public class GenreDTO
    {
        [Required]
        public string Name { get; set; }
    }
}
