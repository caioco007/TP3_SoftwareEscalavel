using TP3_SoftwareEscalavel.Application.Services.Implementations;
using TP3_SoftwareEscalavel.Application.Services.Interfaces;
using TP3_SoftwareEscalavel.Infrastructure.Persistence;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<ProfessorDbContext>();
builder.Services.AddSingleton<ChamadaDbContext>();
builder.Services.AddSingleton<AlunoDbContext>();

builder.Services.AddScoped<IProfessorService, ProfessorService>();
builder.Services.AddScoped<IChamadaService, ChamadaService>();
builder.Services.AddScoped<IAlunoService, AlunoService>();

// Add services to the container.

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
