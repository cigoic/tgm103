using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

using PracticeTGM103.Data;
using PracticeTGM103.Data.TGM103Demo;
using PracticeTGM103.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

var NorthwindConnectionString = builder.Configuration.GetConnectionString("Northwind");
builder.Services.AddDbContext<NorthwindContext>(options =>
    options.UseSqlServer(NorthwindConnectionString));

var TGM103DemoConnectionString = builder.Configuration.GetConnectionString("TGM103Demo");
builder.Services.AddDbContext<TGM103DemoContext>(options =>
    options.UseSqlServer(TGM103DemoConnectionString));

var DemoConnectionString = builder.Configuration.GetConnectionString("Demo");
builder.Services.AddDbContext<DemoContext>(options =>
    options.UseSqlServer(DemoConnectionString));

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
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
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();