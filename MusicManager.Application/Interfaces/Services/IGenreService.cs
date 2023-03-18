using MusicManager.Domain.DTOs;
using MusicManager.Domain.Entities;

namespace MusicManager.Application.Interfaces.Services
{
    /// <summary>
    /// Interface for Genre Service operations.
    /// </summary>
    public interface IGenreService
    {
        /// <summary>
        /// Gets a list of genres asynchronously.
        /// </summary>
        Task<IEnumerable<Genre>> GetGenreListAsync();


        /// <summary>
        /// Retrieves a Genre object by its Id.
        /// </summary>
        Task<Genre> GetGenreByIdAsync(int id);


        /// <summary>
        /// Creates a new Genre based on the provided GenreDTO.
        /// </summary>
        Task<bool> CreateGenreAsync(GenreDTO genreDTO);


        /// <summary>
        /// Creates multiple genres asynchronously.
        /// </summary>
        /// <param name="genreDTOs">A list of genre data transfer
        Task<bool> CreateManyGenresAsync(List<GenreDTO> genreDTOs);


        /// <summary>
        /// Updates the specified genre with the given genreDTO.
        /// </summary>
        Task<bool> UpdateGenreAsync(Genre genre, GenreDTO genreDTO);


        /// <summary>
        /// Asynchronously deletes an genre from the specified genre.
        /// </summary>
        Task<bool> DeleteGenreAsync(Genre genre);


        /// <summary>
        /// Asynchronously finds a genre by its name.
        /// </summary>
        /// <param name="name">The name of the genre to find.</param>
        Task<IEnumerable<Genre>> FindGenreByNameAsync(string name);
    }
}
