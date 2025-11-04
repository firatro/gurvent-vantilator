using FluentValidation;
using FluentValidation.AspNetCore;
using GurventVantilator.AdminUI.Validators.Company;
using GurventVantilator.Application.Extensions;
using GurventVantilator.Application.Validators;
using GurventVantilator.Infrastructure.Data;
using GurventVantilator.Infrastructure.Extensions;
using GurventVantilator.Infrastructure.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// -------------------- DATABASE --------------------
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// -------------------- APPLICATION & INFRASTRUCTURE --------------------
builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices(builder.Configuration);

// -------------------- IDENTITY COOKIE SETTINGS --------------------
// Kullanıcı giriş yapmamışsa otomatik yönlendirme ayarları
builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Account/Login";              // Login sayfası
    options.AccessDeniedPath = "/Account/AccessDenied"; // Yetki yoksa
    options.ExpireTimeSpan = TimeSpan.FromMinutes(60);  // Oturum süresi
    options.SlidingExpiration = true;                   // Aktif kullanımda süre yenilensin
    options.Cookie.HttpOnly = true;
    options.Cookie.Name = "GurventVantilator.Auth";             // Cookie ismi
});

builder.Services.AddAuthorization(options =>
{
    // Yönetim paneline yalnızca Admin ve DevAdmin rollerine izin ver
    options.AddPolicy("AdminPanelAccess", policy =>
        policy.RequireRole("Admin", "DevAdmin"));
});

// -------------------- CONTROLLERS --------------------
builder.Services.AddControllersWithViews(options =>
{
    // 🔹 Yönetim paneli için global rol policy
    var adminPolicy = new AuthorizationPolicyBuilder()
        .RequireRole("Admin", "DevAdmin")
        .Build();

    options.Filters.Add(new AuthorizeFilter(adminPolicy));
});

// -------------------- FLUENT VALIDATION --------------------
builder.Services.AddFluentValidationAutoValidation(options =>
{
    options.DisableDataAnnotationsValidation = true;
})
.AddFluentValidationClientsideAdapters();

// Validatorların bulunduğu assembly’leri tara
builder.Services.AddValidatorsFromAssemblyContaining<CompanyCreateViewModelValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<VersionInfoDtoValidator>();

builder.Services.AddControllersWithViews();

var app = builder.Build();

// -------------------- MIDDLEWARE PIPELINE --------------------
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// Authentication → Authorization sırası ÖNEMLİ
app.UseAuthentication();
app.UseAuthorization();

// -------------------- ROUTING --------------------
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// -------------------- DATABASE SEED --------------------
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var db = services.GetRequiredService<AppDbContext>();
    var roleManager = services.GetRequiredService<RoleManager<ApplicationRole>>();
    var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();

    await DbSeeder.SeedAsync(db, roleManager, userManager);
}

app.Run();

