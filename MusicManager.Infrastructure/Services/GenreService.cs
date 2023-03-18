using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MusicManager.Application.Interfaces.Repositories;
using MusicManager.Application.Interfaces.Services;
using MusicManager.Domain.DTOs;
using MusicManager.Domain.Entities;

namespace MusicManager.Infrastructure.Services
{
    /// <summary>
    /// Represents a service for managing genres.
    /// </summary>
    public class GenreService : IGenreService
    {
        private readonly IGenreRepository _genreRepo;
        private readonly IMapper _mapper;

        public GenreService(IGenreRepository genreRepository, IMapper mapper)
        {
            _genreRepo = genreRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Genre>> GetGenreListAsync()
        {
            return await _genreRepo.GetAllAsync();
        }

        public async Task<Genre> GetGenreByIdAsync(int id)
        {
            return await _genreRepo.GetByIdAsync(id);
        }

        public async Task<bool> CreateGenreAsync(GenreDTO genreDTO)
        {
            Genre genre = _mapper.Map<Genre>(genreDTO);

            genre.CreatedOn = DateTime.Now;
            genre.UpdatedOn = DateTime.Now;

            if (await _genreRepo.AddAsync(genre))
                return await _genreRepo.CompleteAsync();
            return false;
        }

        public async Task<bool> CreateManyGenresAsync(List<GenreDTO> genreDTOs)
        {
            List<Genre> genres = _mapper.Map<List<Genre>>(genreDTOs);

            foreach (var genre in genres)
            {
                genre.CreatedOn = DateTime.Now;
                genre.UpdatedOn = DateTime.Now;
            }

            if (await _genreRepo.AddRangeAsync(genres))
                return await _genreRepo.CompleteAsync();
            return false;
        }

        public async Task<bool> UpdateGenreAsync(Genre genre, GenreDTO genreDTO)
        {
            _mapper.Map(genreDTO, genre);

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
    }
}
