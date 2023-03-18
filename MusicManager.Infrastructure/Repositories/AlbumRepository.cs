using MusicManager.Application.Interfaces.Repositories;
using MusicManager.Domain.Entities;
using MusicManager.Infrastructure.Context;

namespace MusicManager.Infrastructure.Repositories
{
    public class AlbumRepository : BaseRepository<Album>, IAlbumRepostiory
    {
        public AlbumRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
