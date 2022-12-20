using TP3_SoftwareEscalavel.Application.Services.Implementations;
using TP3_SoftwareEscalavel.Application.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddScoped<IAlunoService, AlunoService>();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
object value = builder.Services.AddSwaggerGen();

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
