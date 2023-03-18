using System.ComponentModel.DataAnnotations;

namespace MusicManager.API.DTOs
{
    public class ArtistDTO
    {
        [Required]
        public int Id { get; set; }
    }
}
