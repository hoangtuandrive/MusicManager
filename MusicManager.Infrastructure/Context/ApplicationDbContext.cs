using Microsoft.EntityFrameworkCore;
using MusicManager.Domain.Entities;

namespace MusicManager.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Song> Song { get; set; } = default!;
        public DbSet<Album> Album { get; set; } = default!;
        public DbSet<Genre> Genre { get; set; } = default!;
        public DbSet<Artist> Artist { get; set; } = default!;
    }
}
