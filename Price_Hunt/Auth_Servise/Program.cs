var builder = WebApplication.CreateBuilder(args);

/*Add configuration*/
builder.Configuration.AddJsonFile("Configuration/smtpSettings.json");
builder.Configuration.AddJsonFile("Configuration/rabbitSettings.json");
builder.Configuration.AddJsonFile("Configuration/databaseSettings.json");

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
