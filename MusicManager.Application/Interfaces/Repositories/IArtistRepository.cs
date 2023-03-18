using MusicManager.Domain.Entities;

namespace MusicManager.API.Interfaces.Repositories
{
    /// <summary>
    /// Represents an interface for an Artist Repository which inherits from IBaseRepository.
    /// </summary>
    public interface IArtistRepository : IBaseRepository<Artist>
    {
    }
}
