using data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var DB_CONN_KEY = builder.Configuration.GetConnectionString("Default");
var DB_CONN_VAL = Environment.GetEnvironmentVariable("DB_CONN");
var DB_CONN = DB_CONN_KEY?.Replace("${DB_CONN}", DB_CONN_VAL);

builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(DB_CONN));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
