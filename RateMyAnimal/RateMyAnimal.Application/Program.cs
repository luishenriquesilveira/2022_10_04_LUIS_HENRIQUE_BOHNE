using Microsoft.EntityFrameworkCore;
using RateMyAnimal.Application.Configurations;
using RateMyAnimal.Infrastructure.Context;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(
    x => x.UseSqlServer(builder.Configuration.GetConnectionString("rateMyAnimal"))
);

builder.Services.AddControllersWithViews();

builder.Services.AddServicesDependencyGroup();
builder.Services.AddRepositoryDependencyGroup();

builder.Services.AddAutoMapper(typeof(AutoMapperConfiguration));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
