using MusicManager.Application.Interfaces.Repositories;
using MusicManager.Domain.Entities;
using MusicManager.Infrastructure.Data;

namespace MusicManager.Infrastructure.Repositories
{
    public class GenreRepository : BaseRepository<Genre>, IGenreRepository
    {
        public GenreRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
