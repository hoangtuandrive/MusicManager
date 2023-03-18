using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MusicManager.Application.Interfaces.Repositories;
using MusicManager.Application.Interfaces.Services;
using MusicManager.Infrastructure.Data;
using MusicManager.Infrastructure.Mapper;
using MusicManager.Infrastructure.Repositories;
using MusicManager.Infrastructure.Services;

namespace MusicManager.Infrastructure.Extensions
{
    public static class InfrastructureExtension
    {
        public static IServiceCollection AddInfrastructureExtension(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("MusicManagerConnectionString")));

            #region Repositories

            services.AddScoped<IArtistRepository, ArtistRepository>();

            #endregion Repositories


            #region Services

            services.AddScoped<IArtistService, ArtistService>();

            // Add automapper
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });
            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);

            #endregion Services

            return services;
        }
    }
}
