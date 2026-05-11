using GimnasioAPI.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// 1. Le decimos a la API que use nuestra carpeta de Controladores
builder.Services.AddControllers();

// 2. Configuramos Swagger para la interfaz gráfica
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// 3. Leemos la cadena de conexión del appsettings.json y conectamos MySQL
var connectionString = builder.Configuration.GetConnectionString("ConexionMySQL");
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

var app = builder.Build();

// 4. Activamos Swagger (solo cuando estamos desarrollando localmente)
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// 5. Mapeamos las rutas de nuestros Controladores
app.MapControllers();

app.Run();