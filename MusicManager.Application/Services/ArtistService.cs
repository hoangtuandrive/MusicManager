using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MusicManager.API.Interfaces.Repositories;
using MusicManager.API.Interfaces.Services;
using MusicManager.Application.Models;
using MusicManager.Domain.Entities;

namespace MusicManager.API.Services
{
    public class ArtistService : IArtistService
    {
        private readonly IArtistRepository _artistRepo;
        private readonly IMapper _mapper;

        public ArtistService(IArtistRepository artist, IMapper mapper)
        {
            _artistRepo = artist;
            _mapper = mapper;
        }

        public async Task<List<GetArtistResponseModel>> GetArtistListAsync()
        {
            return await _artistRepo.List()
                .Include(x => x.Albums)
                .Include(x => x.Songs)
                .Select(p => _mapper.Map<GetArtistResponseModel>(p))
                .ToListAsync();
        }

        public async Task<GetArtistResponseModel> GetArtistResponseModelByIdAsync(int id)
        {
            return await _artistRepo.List()
                .Where(x => x.Id == id)
                .Include(x => x.Albums)
                .Include(x => x.Songs)
                .Select(p => _mapper.Map<GetArtistResponseModel>(p))
                .FirstOrDefaultAsync();
        }

        public async Task<Artist> GetArtistByIdAsync(int id)
        {
            return await _artistRepo.GetByIdAsync(id);
        }

        /// <summary>
        /// Async method uses for creating an artist.
        /// </summary>
        /// <param name="artist"></param>
        /// <returns>
        /// True if created successfully, else returns false.
        /// </returns>
        public async Task<bool> CreateArtistAsync(Artist artist)
        {
            artist.CreatedOn = DateTime.Now;
            artist.UpdatedOn = DateTime.Now;

            if (await _artistRepo.AddAsync(artist))
                return await _artistRepo.CompleteAsync();
            return false;
        }

        /// <summary>
        /// Async method uses for creating many artists.
        /// </summary>
        /// <param name="artists"></param>
        /// <returns>
        /// True if created successfully, else returns false.</returns>
        public async Task<bool> CreateManyArtistsAsync(List<Artist> artists)
        {
            foreach (var artist in artists)
            {
                artist.CreatedOn = DateTime.Now;
                artist.UpdatedOn = DateTime.Now;
            }

            if (await _artistRepo.AddRangeAsync(artists))
                return await _artistRepo.CompleteAsync();
            return false;
        }

        /// <summary>
        /// Async method uses for updating an artist.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>
        /// True if update artist successfully. 
        /// False if there's no artist in the database, or update artist failed.
        /// </returns>
        public async Task<bool> UpdateArtistAsync(Artist artist)
        {
            _artistRepo.Update(artist);
            return await _artistRepo.CompleteAsync();
        }

        /// <summary>
        /// Async method uses for deleting an artist.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>
        /// True if update artist successfully. 
        /// False if there's no artist in the database, or update artist failed.
        /// </returns>
        public async Task<bool> DeleteArtistAsync(Artist artist)
        {
            _artistRepo.Remove(artist);
            return await _artistRepo.CompleteAsync();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns>A list of artists whether the specified name substring occured in the artist's name</returns>
        public async Task<List<GetArtistResponseModel>> FindArtistByNameAsync(string name)
        {
            return await _artistRepo.List()
                .Where(x => x.Name.Contains(name))
                .Include(x => x.Albums)
                .Include(x => x.Songs)
                .Select(p => _mapper.Map<GetArtistResponseModel>(p))
                .ToListAsync();
        }


        /// <summary>
        /// Asynchronously retrieves an artist by name.
        /// </summary>
        /// <param name="name">The name of the artist to retrieve.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the first artist with the specified name or null if no such artist is found.</returns>
        public async Task<Artist> GetArtistByNameAsync(string name)
        {
            return await _artistRepo.List().Where(x => x.Name.Equals(name)).FirstOrDefaultAsync();
        }
    }
}
