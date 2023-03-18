using MusicManager.Domain.DTOs;
using MusicManager.Domain.Entities;

namespace MusicManager.Application.Interfaces.Services
{
    public interface IArtistService
    {
        Task<IEnumerable<Artist>> GetArtistListAsync();
        Task<Artist> GetArtistByIdAsync(int id);
        Task<bool> CreateArtistAsync(CreateArtistDTO createArtist);
        Task<bool> UpdateArtistAsync(Artist artist, UpdateArtistDTO updateArtistDTO);
        Task<bool> DeleteArtistAsync(Artist artist);
        Task<IEnumerable<Artist>> FindArtistByNameAsync(string name);
    }
}
