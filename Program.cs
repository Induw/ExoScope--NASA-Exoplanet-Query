using ExoplanetQueryApp.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers();
builder.Services.AddSingleton<ExoplanetService>();

//CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowRenderFrontend", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

var app = builder.Build();

app.UseHttpsRedirection();
app.UseCors("AllowRenderFrontend");
app.UseAuthorization();


app.MapControllers();

app.Run();
