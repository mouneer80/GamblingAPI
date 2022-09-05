using GamblingAPI.Calculations;
using GamblingAPI.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlite("Data Source = Gambling.db");
});
builder.Services.AddScoped<IPlayersRepo, PlayersRepo>();
builder.Services.AddScoped<IValidateRequest, ValidateRequest>();
builder.Services.AddScoped<IHandleRequest, HandleRequest>();
builder.Services.AddScoped<IHandleResponse, HandleResponse>();
builder.Services.AddScoped<IMessages, Messages>();
builder.Services.AddScoped<IGamblingRequest, GamblingRequest>();
builder.Services.AddScoped<IGenerateRndNumber, GenerateRndNumber>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// migrate any database changes on startup (includes initial db creation)
using (var scope = app.Services.CreateScope())
{
    var dataContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    dataContext.Database.Migrate();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
