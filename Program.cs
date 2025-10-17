using backendRickandMorty.Services;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Backend Rick & Morty",
        Version = "v1"
    });

    options.AddServer(new OpenApiServer
    {
        Url = "https://localhost:7290",
        Description = "API Gateway local"
    });
});

// ← AGREGAR CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngular", builder =>
    {
        builder.WithOrigins("http://localhost:4200")  // URL de tu Angular
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

#region apirick and morty
var baseUrl = "https://rickandmortyapi.com/api";

builder.Services.AddHttpClient<RickAndMortyService>(client =>
{
    client.BaseAddress = new Uri(baseUrl);
});
#endregion

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// COMENTADO para desarrollo
// app.UseHttpsRedirection();

// ← USAR CORS (antes de UseAuthorization)
app.UseCors("AllowAngular");

app.UseAuthorization();

app.MapControllers();

app.Run();
