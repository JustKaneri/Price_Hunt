using Auth_Servise.Data;
using Auth_Servise.IntefaceRepository;
using Auth_Servise.Model;
using Auth_Servise.Repository;
using Auth_Servise.Settings;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

/* ����������� AutoMapper */
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

/*Add configuration*/
builder.Configuration.AddJsonFile("Configuration/rabbitSettings.json");
builder.Configuration.AddJsonFile("Configuration/databaseSettings.json");

/* ����������� ������������ */
builder.Services.AddScoped<IPasswordRepository, PasswordRepository>();
builder.Services.AddScoped<ITokenRepository<Token>, TokenRepositroy>();
builder.Services.AddScoped<IEmailCheck, EmailCheck>();
builder.Services.AddScoped<IUserRepository<User>, UserRepository>();
builder.Services.AddScoped<ITokenGenerate,TokenGenerate>();
builder.Services.AddScoped<IAuthRepository,AuthRepository>();
builder.Services.AddScoped<IRabbitMQRepository, RabbitMqRepository>();

/* ��������� ������� */
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

/* ����������� ���� ������ */
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddSwaggerGen(options => SwaggerSetting.AddConfig(options));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
