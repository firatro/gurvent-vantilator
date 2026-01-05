using GurventVantilator.Application.Extensions;
using GurventVantilator.Infrastructure.Data;
using GurventVantilator.Infrastructure.Extensions;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);


// ======================================================
// 1️⃣ SERVISLER
// ======================================================
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddApplicationServices();

// DbContext
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Session servisleri
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

// MVC
builder.Services.AddControllersWithViews();

var app = builder.Build();

// ======================================================
// 3️⃣ PIPELINE
// ======================================================
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

var provider = new FileExtensionContentTypeProvider();
provider.Mappings[".glb"] = "model/gltf-binary";
app.UseStaticFiles(new StaticFileOptions
{
    ContentTypeProvider = provider
});

app.UseRouting();

// Eğer kimlik doğrulama varsa:
app.UseAuthentication();
app.UseAuthorization();

app.UseSession();

// ======================================================
// 4️⃣ ROUTE
// ======================================================
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
