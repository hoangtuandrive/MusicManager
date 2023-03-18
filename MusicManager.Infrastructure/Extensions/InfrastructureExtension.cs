using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MusicManager.Application.Interfaces.Repositories;
using MusicManager.Infrastructure.Context;
using MusicManager.Infrastructure.Repositories;

namespace MusicManager.Infrastructure.Extensions
{
    public static class InfrastructureExtension
    {
        /// <summary>
        /// Extension method to add Infrastructure services to the IServiceCollection.
        /// </summary>
        /// <param name="services">The IServiceCollection to add services to.</param>
        /// <param name="configuration">The configuration to use for the services.</param>
        /// <returns>The IServiceCollection with the added services.</returns>
        public static IServiceCollection AddInfrastructureExtension(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("MusicManagerConnectionString")));

            #region Repositories

            services.AddScoped<IArtistRepository, ArtistRepository>();
            services.AddScoped<IGenreRepository, GenreRepository>();
            services.AddScoped<ISongRepository, SongRepository>();
            services.AddScoped<IAlbumRepostiory, AlbumRepository>();

            #endregion Repositories

            return services;
        }
    }
}
