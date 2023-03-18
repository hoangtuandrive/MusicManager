using System.ComponentModel.DataAnnotations;

namespace MusicManager.Application.Models
{
    public class GetAlbumResponseModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? AvatarImg { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public ICollection<ArtistResponseModel>? Artists { get; set; }
        public ICollection<SongResponseModel>? Songs { get; set; }
        public ICollection<GenreResponseModel>? Genres { get; set; }
    }
}
