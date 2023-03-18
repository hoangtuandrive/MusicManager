using AutoMapper;
using Microsoft.OpenApi.Models;
using MusicManager.API.Mapper;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace MusicManager.API.Extensions
{
    /// <summary>
    /// Extension methods for the Service class.
    /// </summary>
    public static class ServiceExtension
    {
        /// <summary>
        /// Extension method to add Swagger services to the IServiceCollection.
        /// </summary>
        public static void AddSwaggerExtension(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Music Manager",
                    Description = "These APIs will be responsible for overall music management.",
                });

                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });
        }

        /// <summary>
        /// Extension method to add controllers to the IServiceCollection.
        /// </summary>
        public static void AddControllersExtension(this IServiceCollection services)
        {
            services.AddControllers()
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.DictionaryKeyPolicy = JsonNamingPolicy.CamelCase;
                    options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
                    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
                    options.JsonSerializerOptions.WriteIndented = true;
                })
                ;
        }

        /// <summary>
        /// Extension method to add CORS services to the IServiceCollection.
        /// </summary>
        public static void AddCorsExtension(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll",
                builder =>
                {
                    builder.AllowAnyOrigin()
                           .AllowAnyHeader()
                           .AllowAnyMethod();
                });
            });
        }

        /// <summary>
        /// Adds AutoMapper to the service collection and configures it with the MappingProfile.
        /// </summary>
        /// <param name="services">The service collection to add AutoMapper to.</param>
        public static void AddMappingExtension(this IServiceCollection services)
        {
            // Add automapper
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });
            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
