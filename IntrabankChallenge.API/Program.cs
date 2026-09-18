using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using IntrabankChallenge.API.Data;

var builder = WebApplication.CreateBuilder(args);
// Registra o suporte para Controllers
builder.Services.AddControllers();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Removemos a verificação complexa do Swagger por enquanto para garantir o build
app.UseHttpsRedirection();
app.UseAuthorization();
// Mapeia os nossos controladores
app.MapControllers();

app.Run();
