﻿using MusicManager.Application.Models;
using MusicManager.Domain.Entities;

namespace MusicManager.Application.Interfaces.Services
{
    /// <summary>
    /// Interface for providing services related to Albums.
    /// </summary>
    public interface IAlbumService
    {
        /// <summary>
        /// Asynchronously retrieves a list of albums.
        /// </summary>
        Task<List<GetAlbumResponseModel>> GetAlbumListAsync();


        /// <summary>
        /// Asynchronously retrieves an album response model by its ID.
        /// </summary>
        /// <param name="id">The ID of the album to retrieve.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the album response model.</returns>
        Task<GetAlbumResponseModel> GetAlbumResponseModelByIdAsync(int id);


        /// <summary>
        /// Retrieves an album by their ID asynchronously.
        /// </summary>
        Task<Album> GetAlbumByIdAsync(int id);


        /// <summary>
        /// Creates an album asynchronously using the provided Album.
        /// </summary>
        Task<bool> CreateAlbumAsync(Album album);


        /// <summary>
        /// Asynchronously creates multiple albums from a list of albums objects.
        /// </summary>
        Task<bool> CreateManyAlbumsAsync(List<Album> albums);


        /// <summary>
        /// Asynchronously updates an album
        Task<bool> UpdateAlbumAsync(Album album);


        /// <summary>
        /// Asynchronously deletes an Album from the database.
        /// </summary>
        Task<bool> DeleteAlbumAsync(Album album);


        /// <summary>
        /// Asynchronously finds an album by their name.
        /// </summary>
        /// <param name="name">The name of the album to find.</param>
        Task<List<GetAlbumResponseModel>> FindAlbumByNameAsync(string name);


        /// <summary>
        /// Asynchronously retrieves a album by name.
        /// </summary>
        /// <param name="name">The name of the album to retrieve.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the first genre with the specified name or null if no such genre is found.</returns>
        Task<Album> GetAlbumByNameAsync(string name);


        /// <summary>
        /// Adds a song to the specified album asynchronously.
        /// </summary>
        /// <param name="albumId">The ID of the album to add the song to.</param>
        /// <param name="song">The song to add to the album.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains a Boolean value indicating whether the operation was successful.</returns>
        Task<bool> AddSongToAlbumAsync(int albumId, Song song);


        /// <summary>
        /// Remove a song from the specified album asynchronously.
        /// </summary>
        /// <param name="albumId">The ID of the album to remove the song from.</param>
        /// <param name="song">The song to remove from the album.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains a Boolean value indicating whether the operation was successful.</returns>
        Task<bool> RemoveSongFromAlbumAsync(int albumId, Song song);


        /// <summary>
        /// Adds an artist to the specified album asynchronously.
        /// </summary>
        /// <param name="albumId">The ID of the album to add the artist to.</param>
        /// <param name="artist">The artist to add to the album.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains a Boolean value indicating whether the operation was successful.</returns>
        Task<bool> AddArtistToAlbumAsync(int albumId, Artist artist);


        /// <summary>
        /// Remove an artist from the specified album asynchronously.
        /// </summary>
        /// <param name="albumId">The ID of the album to remove the song from.</param>
        /// <param name="artist">The artist to remove from the album.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains a Boolean value indicating whether the operation was successful.</returns>
        Task<bool> RemoveArtistFromAlbumAsync(int albumId, Artist artist);


        /// <summary>
        /// Adds a genre to the specified album asynchronously.
        /// </summary>
        /// <param name="albumId">The ID of the album to add the genre to.</param>
        /// <param name="genre">The genre to add to the album.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains a Boolean value indicating whether the operation was successful.</returns>
        Task<bool> AddGenreToAlbumAsync(int albumId, Genre genre);


        /// <summary>
        /// Remove a genre from the specified album asynchronously.
        /// </summary>
        /// <param name="albumId">The ID of the album to remove the genre from.</param>
        /// <param name="genre">The genre to remove from the album.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains a Boolean value indicating whether the operation was successful.</returns>
        Task<bool> RemoveGenreFromAlbumAsync(int albumId, Genre genre);
    }
}
