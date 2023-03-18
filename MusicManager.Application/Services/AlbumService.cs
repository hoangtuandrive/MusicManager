using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MusicManager.API.Interfaces.Repositories;
using MusicManager.API.Interfaces.Services;
using MusicManager.Application.Models;
using MusicManager.Domain.Entities;

namespace MusicManager.API.Services
{
    public class AlbumService : IAlbumService
    {
        private readonly IAlbumRepostiory _albumRepo;
        private readonly IMapper _mapper;

        public AlbumService(IAlbumRepostiory album, IMapper mapper)
        {
            _albumRepo = album;
            _mapper = mapper;
        }

        public async Task<List<GetAlbumResponseModel>> GetAlbumListAsync()
        {
            return await _albumRepo.List()
               .Include(x => x.Artists)
               .Include(x => x.Songs)
               .Include(x => x.Genres)
               .Select(p => _mapper.Map<GetAlbumResponseModel>(p))
               .ToListAsync();
        }

        public async Task<GetAlbumResponseModel> GetAlbumResponseModelByIdAsync(int id)
        {
            return await _albumRepo.List()
                .Where(x => x.Id == id)
              .Include(x => x.Artists)
              .Include(x => x.Songs)
              .Include(x => x.Genres)
              .Select(p => _mapper.Map<GetAlbumResponseModel>(p))
              .FirstOrDefaultAsync();
        }

        public async Task<Album> GetAlbumByIdAsync(int id)
        {
            return await _albumRepo.GetByIdAsync(id);
        }

        /// <summary>
        /// Async method uses for creating an album.
        /// </summary>
        /// <param name="artist"></param>
        /// <returns>
        /// True if created successfully, else returns false.
        /// </returns>
        public async Task<bool> CreateAlbumAsync(Album album)
        {
            album.CreatedOn = DateTime.Now;
            album.UpdatedOn = DateTime.Now;

            if (await _albumRepo.AddAsync(album))
                return await _albumRepo.CompleteAsync();
            return false;
        }

        /// <summary>
        /// Async method uses for creating many albums.
        /// </summary>
        /// <param name="albums"></param>
        /// <returns>
        /// True if created successfully, else returns false.</returns>
        public async Task<bool> CreateManyAlbumsAsync(List<Album> albums)
        {
            foreach (var album in albums)
            {
                album.CreatedOn = DateTime.Now;
                album.UpdatedOn = DateTime.Now;
            }

            if (await _albumRepo.AddRangeAsync(albums))
                return await _albumRepo.CompleteAsync();
            return false;
        }

        /// <summary>
        /// Async method uses for updating an album.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>
        /// True if update album successfully. 
        /// False if there's no album in the database, or update album failed.
        /// </returns>
        public async Task<bool> UpdateAlbumAsync(Album album)
        {
            _albumRepo.Update(album);
            return await _albumRepo.CompleteAsync();
        }

        /// <summary>
        /// Async method uses for deleting an album.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="updateAlbumDTO"></param>
        /// <returns>
        /// True if update album successfully. 
        /// False if there's no album in the database, or update album failed.
        /// </returns>
        public async Task<bool> DeleteAlbumAsync(Album album)
        {
            _albumRepo.Remove(album);
            return await _albumRepo.CompleteAsync();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns>A list of albums whether the specified name substring occured in the album's name</returns>
        public async Task<List<GetAlbumResponseModel>> FindAlbumByNameAsync(string name)
        {
            return await _albumRepo.List()
              .Where(x => x.Name.Contains(name))
              .Include(x => x.Artists)
              .Include(x => x.Songs)
              .Include(x => x.Genres)
              .Select(p => _mapper.Map<GetAlbumResponseModel>(p))
              .ToListAsync();
        }

        /// <summary>
        /// Asynchronously retrieves an album by name.
        /// </summary>
        /// <param name="name">The name of the genre to retrieve.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the first genre with the specified name or null if no such genre is found.</returns>
        public async Task<Album> GetAlbumByNameAsync(string name)
        {
            return await _albumRepo.List().Where(x => x.Name.Equals(name)).FirstOrDefaultAsync();
        }

        public async Task<bool> AddSongToAlbumAsync(int albumId, Song song)
        {
            var album = await _albumRepo.List()
                .Where(x => x.Id == albumId)
              .Include(x => x.Songs)
              .FirstOrDefaultAsync();

            if (album == null)
                return false;
            album.Songs.Add(song);

            _albumRepo.Update(album);
            return await _albumRepo.CompleteAsync();
        }

        public async Task<bool> RemoveSongFromAlbumAsync(int albumId, Song song)
        {
            var album = await _albumRepo.List()
                .Where(x => x.Id == albumId)
              .Include(x => x.Songs)
              .FirstOrDefaultAsync();

            if (album == null)
                return false;
            album.Songs.Remove(song);

            _albumRepo.Update(album);
            return await _albumRepo.CompleteAsync();
        }

        public async Task<bool> AddArtistToAlbumAsync(int albumId, Artist artist)
        {
            var album = await _albumRepo.List()
               .Where(x => x.Id == albumId)
             .Include(x => x.Artists)
             .FirstOrDefaultAsync();

            if (album == null)
                return false;
            album.Artists.Add(artist);

            _albumRepo.Update(album);
            return await _albumRepo.CompleteAsync();
        }

        public async Task<bool> RemoveArtistFromAlbumAsync(int albumId, Artist artist)
        {
            var album = await _albumRepo.List()
               .Where(x => x.Id == albumId)
             .Include(x => x.Artists)
             .FirstOrDefaultAsync();

            if (album == null)
                return false;
            album.Artists.Remove(artist);

            _albumRepo.Update(album);
            return await _albumRepo.CompleteAsync();
        }

        public async Task<bool> AddGenreToAlbumAsync(int albumId, Genre genre)
        {
            var album = await _albumRepo.List()
               .Where(x => x.Id == albumId)
             .Include(x => x.Genres)
             .FirstOrDefaultAsync();

            if (album == null)
                return false;
            album.Genres.Add(genre);

            _albumRepo.Update(album);
            return await _albumRepo.CompleteAsync();
        }

        public async Task<bool> RemoveGenreFromAlbumAsync(int albumId, Genre genre)
        {
            var album = await _albumRepo.List()
               .Where(x => x.Id == albumId)
             .Include(x => x.Genres)
             .FirstOrDefaultAsync();

            if (album == null)
                return false;
            album.Genres.Remove(genre);

            _albumRepo.Update(album);
            return await _albumRepo.CompleteAsync();
        }
    }
}
