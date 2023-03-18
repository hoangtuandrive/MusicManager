using MusicManager.Application.Interfaces.Repositories;
using MusicManager.Domain.Entities;
using MusicManager.Infrastructure.Context;

namespace MusicManager.Infrastructure.Repositories
{
    public class SongRepository : BaseRepository<Song>, ISongRepository
    {
        public SongRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
