using AutoMapper;
using MusicManager.Application.Interfaces.Repositories;
using MusicManager.Application.Interfaces.Services;
using MusicManager.Domain.DTOs;
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
        /// Async method uses for updating an artist.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="updateArtistDTO"></param>
        /// <returns>
        /// True if update artist successfully. 
        /// False if there's no artist in the database, or update artist failed.
        /// </returns>
        public async Task<bool> UpdateArtistAsync(int id, UpdateArtistDTO updateArtistDTO)
        {
            Artist artist = _mapper.Map<Artist>(updateArtistDTO);
            artist.Id = id;

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
        public async Task<bool> DeleteArtistAsync(Artist artistDb)
        {
            _artistRepo.Remove(artistDb);
            return await _artistRepo.CompleteAsync();
        }
    }
}
