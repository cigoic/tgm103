using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

using WuliKaWu;
using WuliKaWu.Data;
using WuliKaWu.Models;

var builder = WebApplication.CreateBuilder(args);
//MVC網站服務
builder.Services.AddControllersWithViews();
//加入Session服務
builder.Services.AddSession(
    (options) =>
    {
        options.IdleTimeout = TimeSpan.FromMinutes(60);
    }
    );
// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

var ShopConnectionString = builder.Configuration.GetConnectionString("DevelopmentDbConnection");
builder.Services.AddDbContext<ShopContext>(options =>
    options.UseSqlServer(ShopConnectionString));

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddControllersWithViews();

// 設定密碼原則
builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireNonAlphanumeric = true; // 非文、數字（亦即特殊字元）
    options.Password.RequireUppercase = true;
    options.Password.RequiredLength = 12;
    options.Password.RequiredUniqueChars = 1;   // 至少一個不重複字元：aaBB11$$

    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);   // 帳號鎖定時間
    options.Lockout.MaxFailedAccessAttempts = 3;    // 失敗只能重複登入三次
    options.Lockout.AllowedForNewUsers = true;

    options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+"; //這樣設定，不支援中文
    options.User.RequireUniqueEmail = true; // email 不重複
});

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

app.UseSession();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();