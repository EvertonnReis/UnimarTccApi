using UnimarTcc.Application.Services;
using UnimarTcc.Domain.Interfaces;
using UnimarTcc.Infrastructure.Firebase;
using UnimarTcc.Infrastructure.Repositories;

Environment.SetEnvironmentVariable(
    "GOOGLE_APPLICATION_CREDENTIALS",
    Path.Combine(Directory.GetCurrentDirectory(), "Firebase/firebase-key.json")
);

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<FirebaseContext>();

builder.Services.AddScoped<IProfessorRepository, ProfessorRepository>();

builder.Services.AddScoped<ProfessorService>();

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
