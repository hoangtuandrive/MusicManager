using MusicManager.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace MusicManager.Domain.DTOs
{
    public class UpdateArtistDTO
    {
        [Required]
        public string Name { get; set; }
        public Gender? Gender { get; set; }
        public string? Description { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? Country { get; set; }
        public string? AvatarImg { get; set; }
    }
}
