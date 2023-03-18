using MusicManager.Domain.Entities;

namespace MusicManager.Application.Interfaces.Repositories
{
    public interface IArtistRepository : IBaseRepository<Artist>
    {
        Task<IEnumerable<Artist>> FindArtistByNameAsync(string name);
    }
}
