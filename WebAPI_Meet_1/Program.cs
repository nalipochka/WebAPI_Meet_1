using Microsoft.EntityFrameworkCore;
using WebAPI_Meet_1.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

string connStr = builder.Configuration.GetConnectionString("MyGarageDb");
builder.Services.AddDbContext<CarsDbContext>(options =>
{
    options.UseSqlServer(connStr);
});

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
app.UseDefaultFiles();
app.UseStaticFiles();
app.MapControllers();

app.Run();
