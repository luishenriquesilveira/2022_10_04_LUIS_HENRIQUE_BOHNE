using Microsoft.EntityFrameworkCore;
using RateMyAnimal.Api.Configurations;
using RateMyAnimal.Infrastructure.Context;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(
    x => x.UseSqlServer(builder.Configuration.GetConnectionString("connection"))
);

builder.Services.AddControllers();

builder.Services.AddServicesDependencyGroup();
builder.Services.AddRepositoryDependencyGroup();

builder.Services.AddAutoMapper(typeof(AutoMapperConfiguration));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
