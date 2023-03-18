using MusicManager.Domain.DTOs;
using MusicManager.Domain.Entities;

namespace MusicManager.Application.Interfaces.Services
{
    /// <summary>
    /// Interface for providing services related to Artists.
    /// </summary>
    public interface IArtistService
    {
        /// <summary>
        /// Asynchronously retrieves a list of artists.
        /// </summary>
        Task<IEnumerable<Artist>> GetArtistListAsync();


        /// <summary>
        /// Retrieves an artist by their ID asynchronously.
        /// </summary>
        Task<Artist> GetArtistByIdAsync(int id);


        /// <summary>
        /// Creates an artist asynchronously using the provided CreateArtistDTO.
        /// </summary>
        Task<bool> CreateArtistAsync(CreateArtistDTO createArtist);


        /// <summary>
        /// Asynchronously creates multiple artists from a list of CreateManyArtistsDTO objects.
        /// </summary>
        Task<bool> CreateManyArtistsAsync(List<CreateArtistDTO> createManyArtistsDTO);


        /// <summary>
        /// Asynchronously updates an Artist with the given UpdateArtistDTO.
        /// </summary>
        Task<bool> UpdateArtistAsync(Artist artist, UpdateArtistDTO updateArtistDTO);


        /// <summary>
        /// Asynchronously deletes an Artist from the database.
        /// </summary>
        Task<bool> DeleteArtistAsync(Artist artist);


        /// <summary>
        /// Asynchronously finds an artist by their name.
        /// </summary>
        /// <param name="name">The name of the artist to find.</param>
        Task<IEnumerable<Artist>> FindArtistByNameAsync(string name);
    }
}
