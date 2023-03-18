using MusicManager.API.Extension;
using MusicManager.Infrastructure.Extensions;

//try
//{
var builder = WebApplication.CreateBuilder(args);

// Extensions
builder.Services.AddInfrastructureExtension(builder.Configuration);
builder.Services.AddSwaggerExtension();
builder.Services.AddControllersExtension();
builder.Services.AddCorsExtension();

// API Explorer
builder.Services.AddMvcCore()
    .AddApiExplorer();

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseCors("AllowAll");
app.UseSwaggerExtension();

app.MapControllers();

app.Run();

//}
//catch (Exception ex)
//{
//    //Log.Warning(ex, "An error occurred starting the application");
//}
//finally
//{
//    //Log.CloseAndFlush();
//}