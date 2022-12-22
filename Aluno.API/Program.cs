using Microsoft.EntityFrameworkCore;
using TP3_SoftwareEscalavel.Application.Services.Implementations;
using TP3_SoftwareEscalavel.Application.Services.Integration;
using TP3_SoftwareEscalavel.Application.Services.Interfaces;
using TP3_SoftwareEscalavel.Infrastructure.Persistence;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("TP3Microsservico");
builder.Services.AddDbContext<TP3MicrosservicoDbContext>(options => options.UseSqlServer(connectionString));


builder.Services.AddScoped<IProfessorService, ProfessorService>();
builder.Services.AddScoped<IChamadaService, ChamadaService>();
builder.Services.AddScoped<IAlunoService, AlunoService>();
builder.Services.AddScoped<IAlunoIntegration, AlunoIntegration>();
builder.Services.AddScoped<IDisciplinaService, DisciplinaService>();
builder.Services.AddScoped<IDisciplinaAlunosService, DisciplinaAlunosService>();
builder.Services.AddScoped<IAtividadeService, AtividadeService>();
builder.Services.AddScoped<IAtividadeAlunosService, AtividadeAlunosService>();
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
