using Microsoft.EntityFrameworkCore;
using MusicManager.API.Interfaces.Repositories;
using MusicManager.API.Interfaces.Services;
using MusicManager.Domain.Entities;

namespace MusicManager.API.Services
{
    /// <summary>
    /// Represents a service for managing genres.
    /// </summary>
    public class GenreService : IGenreService
    {
        private readonly IGenreRepository _genreRepo;

        public GenreService(IGenreRepository genreRepository)
        {
            _genreRepo = genreRepository;
        }

        public async Task<IEnumerable<Genre>> GetGenreListAsync()
        {
            return await _genreRepo.GetAllAsync();
        }

        public async Task<Genre> GetGenreByIdAsync(int id)
        {
            return await _genreRepo.GetByIdAsync(id);
        }

        public async Task<bool> CreateGenreAsync(Genre genre)
        {
            genre.CreatedOn = DateTime.Now;
            genre.UpdatedOn = DateTime.Now;

            if (await _genreRepo.AddAsync(genre))
                return await _genreRepo.CompleteAsync();
            return false;
        }

        public async Task<bool> CreateManyGenresAsync(List<Genre> genres)
        {
            foreach (var genre in genres)
            {
                genre.CreatedOn = DateTime.Now;
                genre.UpdatedOn = DateTime.Now;
            }

            if (await _genreRepo.AddRangeAsync(genres))
                return await _genreRepo.CompleteAsync();
            return false;
        }

        public async Task<bool> UpdateGenreAsync(Genre genre)
        {
            _genreRepo.Update(genre);
            return await _genreRepo.CompleteAsync();
        }

        public async Task<bool> DeleteGenreAsync(Genre genre)
        {
            _genreRepo.Remove(genre);
            return await _genreRepo.CompleteAsync();
        }

        public async Task<IEnumerable<Genre>> FindGenreByNameAsync(string name)
        {
            return await _genreRepo.List().Where(x => x.Name.Contains(name)).ToListAsync();
        }

        /// <summary>
        /// Asynchronously retrieves a genre by name.
        /// </summary>
        /// <param name="name">The name of the genre to retrieve.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the first genre with the specified name or null if no such genre is found.</returns>
        public async Task<Genre> GetGenreByNameAsync(string name)
        {
            return await _genreRepo.List().Where(x => x.Name.Equals(name)).FirstOrDefaultAsync();
        }
    }
}
