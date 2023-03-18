using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusicManager.Domain.Entities
{
    public class Song
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? AvatarImg { get; set; }
        public string? Lyric { get; set; }
        [Column(TypeName = "date")]
        public DateTime ReleaseDate { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public DateTime UpdatedOn { get; set; } = DateTime.Now;
        public ICollection<Artist> Artists { get; set; }
        public ICollection<Genre> Genre { get; set; }
    }
}
