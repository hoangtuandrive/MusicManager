namespace MusicManager.API.Extension
{


    /// <summary>
    /// Contains extension methods for the App class.
    /// </summary>
    public static class AppExtension
    {

        /// <summary>
        /// Extension method to configure Swagger and Swagger UI in the application.
        /// </summary>
        public static void UseSwaggerExtension(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "MusicManager.WebApi");
            });
        }
    }
}
