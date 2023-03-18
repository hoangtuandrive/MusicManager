using MusicManager.Domain.Entities;

namespace MusicManager.Application.Interfaces.Repositories
{
    /// <summary>
    /// Represents an interface for a Genre Repository that inherits from the IBaseRepository interface.
    /// </summary>
    public interface IGenreRepository : IBaseRepository<Genre>
    {
    }
}
