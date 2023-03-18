using MusicManager.API.Data;
using MusicManager.API.Interfaces.Repositories;
using MusicManager.Domain.Entities;

namespace MusicManager.API.Repositories
{
    public class AlbumRepository : BaseRepository<Album>, IAlbumRepostiory
    {
        public AlbumRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
