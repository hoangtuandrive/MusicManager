using MusicManager.API.Data;
using MusicManager.API.Interfaces.Repositories;
using MusicManager.Domain.Entities;

namespace MusicManager.API.Repositories
{
    public class SongRepository : BaseRepository<Song>, ISongRepository
    {
        public SongRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
