using backendRickandMorty.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region apirick and morty
var baseUrl = "https://rickandmortyapi.com/api";

// Registra RickAndMortyService con HttpClient configurado
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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
