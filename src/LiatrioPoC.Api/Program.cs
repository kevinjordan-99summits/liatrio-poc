using LiatrioPoC.Api;
using LiatrioPoC.Core.Repositories;
using LiatrioPoC.InMemoryDb;

var builder = WebApplication.CreateBuilder(args);
var appConfiguration = new AppConfiguration(builder.Configuration);

// Add services to the container.
builder.Services.AddSingleton<IAppConfiguration>(appConfiguration);
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IKataRepository, KataRepository>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
