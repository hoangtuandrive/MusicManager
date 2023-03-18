using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusicManager.Domain.Entities
{
    public class Album
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? AvatarImg { get; set; }
        [Column(TypeName = "date")]
        public DateTime ReleaseDate { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public ICollection<Artist> Artists { get; set; }
        public ICollection<Song> Songs { get; set; }
        public ICollection<Genre> Genres { get; set; }
    }
}
