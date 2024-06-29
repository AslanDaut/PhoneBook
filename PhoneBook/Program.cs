using Microsoft.EntityFrameworkCore;
using PhoneBook.Data;
using PhoneBook.Interfaces;
using PhoneBook.Repository;

var builder = WebApplication.CreateBuilder(args);

// Строка подключения
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Добавление DbContext
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(connectionString));

// Добавление сервисов
builder.Services.AddScoped<ICountryRepository, CountryRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Добавление контроллеров и Swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Конфигурация HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
