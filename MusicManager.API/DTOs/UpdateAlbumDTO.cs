using System.ComponentModel.DataAnnotations;

namespace MusicManager.API.DTOs
{
    public class UpdateAlbumDTO
    {
        [Required]
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? AvatarImg { get; set; }
        public DateTime? ReleaseDate { get; set; }
    }
}
