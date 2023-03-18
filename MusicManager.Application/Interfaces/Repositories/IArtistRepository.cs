using MusicManager.Domain.Entities;

namespace MusicManager.Application.Interfaces.Repositories
{




    /// <summary>
    /// Represents an interface for an Artist Repository which inherits from IBaseRepository.
    /// </summary>




    /// <summary>
    /// Represents an interface for an Artist Repository which inherits from IBaseRepository.
    /// </summary>
    public interface IArtistRepository : IBaseRepository<Artist>
    {
        /// <summary>
        /// Asynchronously finds an artist by their name.
        /// </summary>
        /// <param name="name">The name of the artist to find.</param>
        Task<IEnumerable<Artist>> FindArtistByNameAsync(string name);
    }
}
