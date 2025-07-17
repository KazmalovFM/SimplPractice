using Microsoft.EntityFrameworkCore;
using SimplPractice;
using SimplPractice.Repositories.Interfaces;
using SimplPractice.Repositories.Implementations;
using SimplPractice.Services.Interfaces;
using SimplPractice.Services.Implementations;

var builder = WebApplication.CreateBuilder(args);

// Получение конфигурации
var configuration = builder.Configuration;

// Подключение контекста базы данных EF с SQLite
builder.Services.AddDbContext<SportStoreDbContext>(options =>
{
    options.UseSqlite(configuration.GetConnectionString(nameof(SportStoreDbContext)));
});

// Подключение репозиториев
builder.Services.AddScoped<ICategoriesRepository, CategoriesRepository>();
builder.Services.AddScoped<IClientsRepository, ClientsRepository>();
builder.Services.AddScoped<IDeliveriesRepository, DeliveriesRepository>();
builder.Services.AddScoped<IDeliveryStatusesRepository, DeliveryStatusesRepository>();
builder.Services.AddScoped<IEmployeesRepository, EmployeesRepository>();
builder.Services.AddScoped<IOrderDetailsRepository, OrderDetailsRepository>();
builder.Services.AddScoped<IOrdersRepository, OrdersRepository>();
builder.Services.AddScoped<IPaymentsRepository, PaymentsRepository>();
builder.Services.AddScoped<IProductsRepository, ProductsRepository>();
builder.Services.AddScoped<IStoresRepository, StoresRepository>();
builder.Services.AddScoped<ISuppliersRepository, SuppliersRepository>();


// Подключение сервисов
builder.Services.AddScoped<ICategoriesService, CategoriesService>();
builder.Services.AddScoped<IClientsService, ClientsService>();
builder.Services.AddScoped<IDeliveriesService, DeliveriesService>();
builder.Services.AddScoped<IDeliveryStatusesService, DeliveryStatusesService>();
builder.Services.AddScoped<IEmployeesService, EmployeesService>();
builder.Services.AddScoped<IOrderDetailsService, OrderDetailsService>();
builder.Services.AddScoped<IOrdersService, OrdersService>();
builder.Services.AddScoped<IPaymentsService, PaymentsService>();
builder.Services.AddScoped<IProductsService, ProductsService>();
builder.Services.AddScoped<IStoresService, StoresService>();
builder.Services.AddScoped<ISuppliersService, SuppliersService>();

// Добавление контроллеров и Swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Использование Swagger в режиме разработки
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Использование авторизации (если будет, пока можно оставить)
app.UseAuthorization();

// Маршрутизация контроллеров
app.MapControllers();

app.Run();