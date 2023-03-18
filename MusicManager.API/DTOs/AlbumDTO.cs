using System.ComponentModel.DataAnnotations;

namespace MusicManager.API.DTOs
{
    public class AlbumDTO
    {
        [Required]
        public int Id { get; set; }
    }
}
