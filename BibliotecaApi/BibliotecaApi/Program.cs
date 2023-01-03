using BibliotecaApi.Dominio.Interface;
using BibliotecaApi.Dominio.Model;
using BibliotecaApi.Dominio.ViewModel;
using BibliotecaApi.Infra;
using BibliotecaApi.Infra._4._1___Infra;
using BibliotecaApi.Servicos.Interface;
using BibliotecaApi.Servicos.Servicos;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

string mySqlConnection = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<BibliotecaApiContext>(options =>
options.UseMySql(mySqlConnection, ServerVersion.AutoDetect(mySqlConnection)));

builder.Services.AddScoped<IAutorRepository, AutorRepository>();
builder.Services.AddScoped<IEditoraRepository, EditoraRepository>();
builder.Services.AddScoped<ILivroRepository, LivroRepository>();

builder.Services.AddScoped<IAutorServico, AutorServico>();
builder.Services.AddScoped<IEditoraServico, EditoraServico>();
builder.Services.AddScoped<ILivroServico, LivroServico>();

builder.Services.AddAutoMapper(mapper =>
{
    mapper.CreateMap<AutorViewModel, Autor>().ReverseMap();
    mapper.CreateMap<EditoraViewModel, Editora>().ReverseMap();
    mapper.CreateMap<LivroViewModel, Livro>().ReverseMap();
});

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
