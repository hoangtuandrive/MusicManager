using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MusicManager.Application.DTOs;
using MusicManager.Application.Interfaces.Repositories;
using MusicManager.Application.Interfaces.Services;
using MusicManager.Domain.Entities;

namespace MusicManager.Infrastructure.Services
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

        public async Task<IEnumerable<Artist>> GetArtistListAsync()
        {
            return await _artistRepo.GetAllAsync();
        }

        public async Task<Artist> GetArtistByIdAsync(int id)
        {
            return await _artistRepo.GetByIdAsync(id);
        }

        /// <summary>
        /// Async method uses for creating an artist.
        /// </summary>
        /// <param name="createArtistDTO"></param>
        /// <returns>
        /// True if created successfully, else returns false.
        /// </returns>
        public async Task<bool> CreateArtistAsync(CreateArtistDTO createArtistDTO)
        {
            Artist artist = _mapper.Map<Artist>(createArtistDTO);

            artist.CreatedOn = DateTime.Now;
            artist.UpdatedOn = DateTime.Now;

            if (await _artistRepo.AddAsync(artist))
                return await _artistRepo.CompleteAsync();
            return false;
        }

        /// <summary>
        /// Async method uses for creating many artists.
        /// </summary>
        /// <param name="createManyArtistsDTO"></param>
        /// <returns>
        /// True if created successfully, else returns false.</returns>
        public async Task<bool> CreateManyArtistsAsync(List<CreateArtistDTO> createManyArtistsDTO)
        {
            List<Artist> artists = _mapper.Map<List<Artist>>(createManyArtistsDTO);

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
        /// <param name="updateArtistDTO"></param>
        /// <returns>
        /// True if update artist successfully. 
        /// False if there's no artist in the database, or update artist failed.
        /// </returns>
        public async Task<bool> UpdateArtistAsync(Artist artist, UpdateArtistDTO updateArtistDTO)
        {
            _mapper.Map(updateArtistDTO, artist);

            _artistRepo.Update(artist);
            return await _artistRepo.CompleteAsync();
        }

        /// <summary>
        /// Async method uses for deleting an artist.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="updateArtistDTO"></param>
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
        public async Task<IEnumerable<Artist>> FindArtistByNameAsync(string name)
        {
            return await _artistRepo.List().Where(x => x.Name.Contains(name)).ToListAsync();
        }
    }
}
