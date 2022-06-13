using FilmesAPI.Data;
using FilmesAPI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Proxies;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Configurando para acessar o banco de dados
string mySqlConnection = builder.Configuration.GetConnectionString("FilmeConnection");
builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseLazyLoadingProxies()
                .UseMySql(mySqlConnection,
                      ServerVersion.AutoDetect(mySqlConnection)));
// Adicionando para fazer o mapeamento entre diferentes classes
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddScoped<CinemaService, CinemaService>();
builder.Services.AddScoped<EnderecoService, EnderecoService>();
builder.Services.AddScoped<FilmeService, FilmeService>();
builder.Services.AddScoped<SessaoService, SessaoService>();
builder.Services.AddScoped<GerenteService, GerenteService>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
