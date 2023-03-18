using System.ComponentModel.DataAnnotations;

namespace MusicManager.API.DTOs
{
    public class CreateSongDTO
    {
        [Required]
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? AvatarImg { get; set; }
        public string? Lyric { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public ICollection<AlbumDTO>? Albums { get; set; }
        public ICollection<ArtistDTO>? Artists { get; set; }
        public ICollection<GenreDTO>? Genres { get; set; }
    }
}
