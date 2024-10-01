using DecideTuCancha.DBContext.Interface;
using DecideTuCancha.DBContext.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// Configuración de los repositorios
builder.Services.AddTransient<ICanchaRepository, CanchaRepository>();
builder.Services.AddTransient<IComplejoRepository, ComplejoRepository>();
builder.Services.AddTransient<IReservaRepository, ReservaRepository>();
builder.Services.AddTransient<ISedeRepository, SedeRepository>();
builder.Services.AddTransient<ITipoCanchaRepository, TipoCanchaRepository>();
builder.Services.AddTransient<IUsuarioRepository, UsuarioRepository>();

// Habilitar Swagger
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Decide tu cancha",
        Version = "v1",
        Description = "Documentación de la API",
        Contact = new OpenApiContact
        {
            Name = "Grupo 5",
            Email = "grupo5upc@upc.edu.pe"
        },
    });
});

var app = builder.Build();

// Configuración del middleware
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();
app.UseRouting();

// Habilitar Swagger
app.UseSwagger(); // Activar Swagger
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Mi API v1");
    c.RoutePrefix = string.Empty;
});

app.UseAuthorization();
app.MapControllers();

app.Run();
