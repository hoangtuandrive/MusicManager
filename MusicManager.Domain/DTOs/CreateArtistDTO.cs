using MusicManager.Domain.Enums;

namespace MusicManager.Domain.DTOs
{
    public class CreateArtistDTO
    {
        public string Name { get; set; }
        public Gender? Gender { get; set; }
        public string? Description { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? Country { get; set; }
        public string? AvatarImg { get; set; }
    }
}
