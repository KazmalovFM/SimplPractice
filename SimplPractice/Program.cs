using Microsoft.EntityFrameworkCore;
using SimplPractice;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;

/// <summary>
/// Подключение DbContext
/// </summary>
builder.Services.AddDbContext<SportStoreDbContext>(options =>
{
    options.UseSqlite(configuration.GetConnectionString(nameof(SportStoreDbContext)));
});

/// <summary>
/// Автоматическая регистрация всех Repository и Service
/// </summary>
RegisterByEnding(builder.Services, "Repository");
RegisterByEnding(builder.Services, "Service");

/// <summary>
/// Метод автоматической регистрации классов по суффиксу
/// </summary>
void RegisterByEnding(IServiceCollection services, string ending)
{
    var assembly = Assembly.GetExecutingAssembly();

    foreach (var type in assembly.GetTypes()
        .Where(t => t.IsClass && !t.IsAbstract && t.Name.EndsWith(ending)))
    {
        var interfaceType = type.GetInterface($"I{type.Name}");
        if (interfaceType != null)
        {
            services.AddScoped(interfaceType, type);
        }
    }
}

/// <summary>
/// Добавление контроллеров и Swagger
/// </summary>
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.MapControllers();
app.Run();