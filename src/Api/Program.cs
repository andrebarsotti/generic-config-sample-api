using Domain.Dto;
using Domain.Serialization;
using Domain.Validators;

using FluentValidation;

using Repositories.Extensions;


EntitiesSerializationMapper.MapEntities();

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMongoDBRepositories(builder.Configuration);
builder.Services.AddScoped <Domain.Services.IRegrasService, Domain.Services.RegrasService>();
builder.Services.AddScoped<IValidator<RegraDto>, RegraDtoValidator>();

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
