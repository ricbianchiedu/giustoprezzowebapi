using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<DbArticoli>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DbArticoliContext")));

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

//Forza la porta su cui girerà la app
// app.Urls.Add("https://localhost:5001");
// app.Urls.Add("http://localhost:5000");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
