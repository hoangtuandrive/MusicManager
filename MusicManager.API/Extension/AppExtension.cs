using MusicManager.API.Middlewares;

namespace MusicManager.API.Extension
{
    public static class AppExtension
    {
        public static void UseSwaggerExtension(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "MusicManager.WebApi");
            });
        }

        /// <summary>
        /// Adds the error handling middleware to the application.
        /// </summary>
        public static void UseErrorHandlingMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ErrorHandlerMiddleware>();
        }
    }
}
