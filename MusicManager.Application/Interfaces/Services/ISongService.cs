using MusicManager.Application.Models;
using MusicManager.Domain.Entities;

namespace MusicManager.Application.Interfaces.Services
{
    /// <summary>
    /// Interface for providing services related to Songs.
    /// </summary>
    public interface ISongService
    {
        /// <summary>
        /// Asynchronously retrieves a list of songs.
        /// </summary>
        //Task<IEnumerable<Song>> GetSongListAsync();
        Task<List<GetSongResponseModel>> GetSongListAsync();


        /// <summary>
        /// Asynchronously retrieves a song response model by its ID.
        /// </summary>
        /// <param name="id">The ID of the song to retrieve.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the song response model.</returns>
        Task<GetSongResponseModel> GetSongResponseModelByIdAsync(int id);

        /// <summary>
        /// Retrieves an song by their ID asynchronously.
        /// </summary>
        Task<Song> GetSongByIdAsync(int id);


        /// <summary>
        /// Creates an song asynchronously using the provided song.
        /// </summary>
        Task<bool> CreateSongAsync(Song song);


        /// <summary>
        /// Asynchronously creates multiple songs from a list of songs objects.
        /// </summary>
        Task<bool> CreateManySongsAsync(List<Song> songs);


        /// <summary>
        /// Asynchronously updates an Song with the given song.
        /// </summary>
        Task<bool> UpdateSongAsync(Song song);


        /// <summary>
        /// Asynchronously deletes an Song from the database.
        /// </summary>
        Task<bool> DeleteSongAsync(Song song);


        /// <summary>
        /// Asynchronously finds an song by their name.
        /// </summary>
        /// <param name="name">The name of the song to find.</param>
        Task<List<GetSongResponseModel>> FindSongByNameAsync(string name);


        /// <summary>
        /// Asynchronously retrieves a song by name.
        /// </summary>
        /// <param name="name">The name of the song to retrieve.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the first genre with the specified name or null if no such genre is found.</returns>
        Task<Song> GetSongByNameAsync(string name);


        /// <summary>
        /// Adds an artist to the specified song asynchronously.
        /// </summary>
        /// <param name="songId">The ID of the song to add the artist to.</param>
        /// <param name="artist">The artist to add to the song.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains a Boolean value indicating whether the operation was successful.</returns>
        Task<bool> AddArtistToSongAsync(int songId, Artist artist);


        /// <summary>
        /// Removes an artist from the specified song asynchronously.
        /// </summary>
        /// <param name="songId">The ID of the song to remove the artist from.</param>
        /// <param name="artist">The artist to remove from the song.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains a Boolean value indicating whether the operation was successful.</returns>
        Task<bool> RemoveArtistFromSongAsync(int songId, Artist artist);


        /// <summary>
        /// Adds a genre to the specified song asynchronously.
        /// </summary>
        /// <param name="songId">The ID of the song to add the genre to.</param>
        /// <param name="genre">The genre to add to the song.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains a Boolean value indicating whether the operation was successful.</returns>
        Task<bool> AddGenreToSongAsync(int songId, Genre genre);


        /// <summary>
        /// Removes a genre from the specified song asynchronously.
        /// </summary>
        /// <param name="songId">The ID of the song to remove the genre from.</param>
        /// <param name="genre">The genre to remove from the song.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains a Boolean value indicating whether the operation was successful.</returns>
        Task<bool> RemoveGenreFromSongAsync(int songId, Genre genre);
    }
}
