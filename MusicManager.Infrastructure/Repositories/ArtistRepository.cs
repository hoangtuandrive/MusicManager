using MusicManager.API.Data;
using MusicManager.API.Interfaces.Repositories;
using MusicManager.Domain.Entities;

namespace MusicManager.API.Repositories
{
    public class ArtistRepository : BaseRepository<Artist>, IArtistRepository
    {
        public ArtistRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
