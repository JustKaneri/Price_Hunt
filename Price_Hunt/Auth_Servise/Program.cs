using Auth_Servise.Data;
using Auth_Servise.IntefaceRepository;
using Auth_Servise.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

/* Подключение AutoMapper */
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

/*Add configuration*/
builder.Configuration.AddJsonFile("Configuration/smtpSettings.json");
builder.Configuration.AddJsonFile("Configuration/rabbitSettings.json");
builder.Configuration.AddJsonFile("Configuration/databaseSettings.json");

/* Подключение зависимостей */
builder.Services.AddScoped<IPasswordRepository, PasswordRepository>();


/* Остальные сервисы */
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

/* Подключение базы данных */
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
