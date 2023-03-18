using MusicManager.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace MusicManager.Application.Models
{
    public class GetArtistResponseModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public Gender? Gender { get; set; }
        public string? Description { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? Country { get; set; }
        public string? AvatarImg { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public ICollection<AlbumResponseModel>? Albums { get; set; }
        public ICollection<SongResponseModel>? Songs { get; set; }
    }
}
