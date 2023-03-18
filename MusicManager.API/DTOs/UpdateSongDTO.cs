using System.ComponentModel.DataAnnotations;

namespace MusicManager.API.DTOs
{
    public class UpdateSongDTO
    {
        [Required]
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? AvatarImg { get; set; }
        public string? Lyric { get; set; }
        public DateTime? ReleaseDate { get; set; }
    }
}
