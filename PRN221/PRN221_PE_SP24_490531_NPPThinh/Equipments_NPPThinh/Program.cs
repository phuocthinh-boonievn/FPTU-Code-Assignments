using Equipments_Repository.Models;
using Equipments_Repository.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddSession();

builder.Services.AddScoped<UnitOfWork, UnitOfWork>();
builder.Services.AddDbContext<Equipments2024DbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DBConnect")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseSession();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
