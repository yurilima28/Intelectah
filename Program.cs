using Intelectah.Data;
using Intelectah.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<BancoContext>(o=>o.UseSqlServer(connectionString));


builder.Services.AddScoped<IPacienteRepository, PacienteRepository>();
builder.Services.AddScoped<ITipoExameRepository, TipoExameRepository>();
builder.Services.AddScoped<IExameRepository, ExameRepository>();
builder.Services.AddScoped<IConsultaRepository, ConsultaRepository>();




var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


app.Run();
