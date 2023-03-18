using Microsoft.Extensions.DependencyInjection;
using MusicManager.API.Interfaces.Services;
using MusicManager.API.Services;

namespace MusicManager.Application.Extensions
{
    public static class ApplicationExtension
    {
        /// <summary>
        /// Extension method to add Application services to the IServiceCollection.
        /// </summary>
        /// <param name="services">The IServiceCollection to add services to.</param>
        /// <param name="configuration">The configuration to use for the services.</param>
        /// <returns>The IServiceCollection with the added services.</returns>
        public static IServiceCollection AddApplicationExtension(this IServiceCollection services)
        {
            #region Services

            services.AddScoped<IArtistService, ArtistService>();
            services.AddScoped<IGenreService, GenreService>();
            services.AddScoped<ISongService, SongService>();
            services.AddScoped<IAlbumService, AlbumService>();

            #endregion Services

            return services;
        }
    }
}
