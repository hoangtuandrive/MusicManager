using MusicManager.Application.Models;
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
        Task<List<GetArtistResponseModel>> GetArtistListAsync();


        /// <summary>
        /// Asynchronously retrieves an artist response model by its ID.
        /// </summary>
        /// <param name="id">The ID of the artist to retrieve.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the artist response model.</returns>
        Task<GetArtistResponseModel> GetArtistResponseModelByIdAsync(int id);


        /// <summary>
        /// Retrieves an artist by their ID asynchronously.
        /// </summary>
        Task<Artist> GetArtistByIdAsync(int id);


        /// <summary>
        /// Creates an artist asynchronously using the provided artist.
        /// </summary>
        Task<bool> CreateArtistAsync(Artist artist);


        /// <summary>
        /// Asynchronously creates multiple artists from a list of artist objects.
        /// </summary>
        Task<bool> CreateManyArtistsAsync(List<Artist> artist);


        /// <summary>
        /// Asynchronously updates an Artist
        /// </summary>
        Task<bool> UpdateArtistAsync(Artist artist);


        /// <summary>
        /// Asynchronously deletes an Artist from the database.
        /// </summary>
        Task<bool> DeleteArtistAsync(Artist artist);


        /// <summary>
        /// Asynchronously finds an artist by their name.
        /// </summary>
        /// <param name="name">The name of the artist to find.</param>
        Task<List<GetArtistResponseModel>> FindArtistByNameAsync(string name);


        /// <summary>
        /// Asynchronously retrieves a artist by name.
        /// </summary>
        /// <param name="name">The name of the artist to retrieve.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the first genre with the specified name or null if no such genre is found.</returns>
        Task<Artist> GetArtistByNameAsync(string name);
    }
}
