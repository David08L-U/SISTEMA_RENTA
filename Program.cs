using Microsoft.EntityFrameworkCore;
using RentaDepartamentosWeb.Data;
using RentaDepartamentosWeb.Repositories;
using RentaDepartamentosWeb.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IDepartamentoRepository, DepartamentoRepositorySql>();
builder.Services.AddScoped<IDepartamentoService, DepartamentoService>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Departamento/Dashboard");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();
app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Departamento}/{action=Dashboard}/{id?}")
    .WithStaticAssets();

app.Run();
