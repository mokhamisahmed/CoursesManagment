using IdentityItI.Database;
using IdentityItI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<DataBaseConnection>(
    option => option.UseSqlServer(builder.Configuration.GetConnectionString("connection"))
    ) ;

builder.Services.AddScoped<DataBaseConnection, DataBaseConnection>();

builder.Services.AddIdentity<ApplicationUser,IdentityRole>().AddEntityFrameworkStores<DataBaseConnection>();
builder.Services.AddScoped<RoleManager<IdentityRole>, RoleManager<IdentityRole>>();

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
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Acc}/{action=LogIn}/{id?}");

app.Run();
