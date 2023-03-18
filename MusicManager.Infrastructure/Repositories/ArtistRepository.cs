using Microsoft.EntityFrameworkCore;
using MusicManager.Application.Interfaces.Repositories;
using MusicManager.Domain.Entities;
using MusicManager.Infrastructure.Data;

namespace MusicManager.Infrastructure.Repositories
{
    public class ArtistRepository : BaseRepository<Artist>, IArtistRepository
    {
        public ArtistRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Artist>> FindArtistByNameAsync(string name)
        {
            return await _context.Artist.Where(x => x.Name.Contains(name)).ToListAsync();
        }
    }
}
