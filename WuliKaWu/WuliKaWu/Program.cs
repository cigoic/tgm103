using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

using System.Net.Mail;

using WuliKaWu.Data;
using WuliKaWu.Services;

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

// Local 端開發使用的 SQL Server 連線字串
//var ShopConnectionString = builder.Configuration.GetConnectionString("DevelopmentDbConnection");
//builder.Services.AddDbContext<ShopContext>(options =>
//    options.UseSqlServer(ShopConnectionString));

// Smart ASP MySQL 連線字串
var SmartASPConnectionString = builder.Configuration.GetConnectionString("SmartASPConnection");
//var SmartASPConnectionString = Environment.GetEnvironmentVariable("SmartASPConnection");

builder.Services.AddDbContext<ShopContext>(options =>
    options.UseSqlServer(SmartASPConnectionString));

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddTransient<SmtpClient>();
builder.Services.AddTransient<IMailService, SmtpMailingService>();

builder.Services.AddControllersWithViews();

// 註冊自訂登入驗證服務
builder.Services
    .AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(opt =>
    {
        opt.AccessDeniedPath = "/Home/Error";   // 驗證失敗時，轉至此頁面
        opt.LoginPath = "/Member/Login";     // 當應當要登入，卻沒經過登入頁面時，轉至此頁面
        opt.ExpireTimeSpan = TimeSpan.FromSeconds(86400);
        opt.Cookie.Name = "WuliKaWuCookie";
        opt.Cookie.HttpOnly = true;
        opt.LogoutPath = "/";
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
//app.MapRazorPages();      // 使用 Identity 時需取消註解

app.Run();