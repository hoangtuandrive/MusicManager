using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MusicManager.API.Interfaces.Repositories;
using MusicManager.API.Interfaces.Services;
using MusicManager.Application.Models;
using MusicManager.Domain.Entities;

namespace MusicManager.API.Services
{
    public class SongService : ISongService
    {
        private readonly ISongRepository _songRepo;
        private readonly IMapper _mapper;

        public SongService(ISongRepository song, IMapper mapper)
        {
            _songRepo = song;
            _mapper = mapper;
        }

        public async Task<List<GetSongResponseModel>> GetSongListAsync()
        {
            return await _songRepo.List()
                .Include(x => x.Artists)
                .Include(x => x.Albums)
                .Include(x => x.Genres)
                .Select(p => _mapper.Map<GetSongResponseModel>(p))
                .ToListAsync();
        }

        public async Task<GetSongResponseModel> GetSongResponseModelByIdAsync(int id)
        {
            return await _songRepo.List()
                .Where(x => x.Id == id)
                .Include(x => x.Artists)
                .Include(x => x.Albums)
                .Include(x => x.Genres)
                .Select(p => _mapper.Map<GetSongResponseModel>(p))
                .FirstOrDefaultAsync();
        }

        public async Task<Song> GetSongByIdAsync(int id)
        {
            return await _songRepo.GetByIdAsync(id);
        }

        /// <summary>
        /// Async method uses for creating an song.
        /// </summary>
        /// <param name="song"></param>
        /// <returns>
        /// True if created successfully, else returns false.
        /// </returns>
        public async Task<bool> CreateSongAsync(Song song)
        {
            song.CreatedOn = DateTime.Now;
            song.UpdatedOn = DateTime.Now;

            if (await _songRepo.AddAsync(song))
                return await _songRepo.CompleteAsync();
            return false;
        }

        /// <summary>
        /// Async method uses for creating many songs.
        /// </summary>
        /// <param name="songs"></param>
        /// <returns>
        /// True if created successfully, else returns false.</returns>
        public async Task<bool> CreateManySongsAsync(List<Song> songs)
        {
            foreach (var song in songs)
            {
                song.CreatedOn = DateTime.Now;
                song.UpdatedOn = DateTime.Now;
            }

            if (await _songRepo.AddRangeAsync(songs))
                return await _songRepo.CompleteAsync();
            return false;
        }

        /// <summary>
        /// Async method uses for updating an song.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>
        /// True if update song successfully. 
        /// False if there's no song in the database, or update song failed.
        /// </returns>
        public async Task<bool> UpdateSongAsync(Song song)
        {
            song.UpdatedOn = DateTime.Now;

            _songRepo.Update(song);
            return await _songRepo.CompleteAsync();
        }

        /// <summary>
        /// Async method uses for deleting an song.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="updateSongDTO"></param>
        /// <returns>
        /// True if update song successfully. 
        /// False if there's no song in the database, or update song failed.
        /// </returns>
        public async Task<bool> DeleteSongAsync(Song song)
        {
            _songRepo.Remove(song);
            return await _songRepo.CompleteAsync();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns>A list of songs whether the specified name substring occured in the song's name</returns>
        public async Task<List<GetSongResponseModel>> FindSongByNameAsync(string name)
        {
            return await _songRepo.List()
                .Where(x => x.Name.Contains(name))
                .Include(x => x.Artists)
                .Include(x => x.Albums)
                .Include(x => x.Genres)
                .Select(p => _mapper.Map<GetSongResponseModel>(p))
                .ToListAsync();
        }

        /// <summary>
        /// Asynchronously retrieves a song by name.
        /// </summary>
        /// <param name="name">The name of the song to retrieve.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the first genre with the specified name or null if no such genre is found.</returns>
        public async Task<Song> GetSongByNameAsync(string name)
        {
            return await _songRepo.List().Where(x => x.Name.Equals(name)).FirstOrDefaultAsync();
        }
    }
}
