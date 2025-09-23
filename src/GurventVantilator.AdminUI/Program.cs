using FluentValidation;
using FluentValidation.AspNetCore;
using GurventVantilator.AdminUI.Validators.Company;
using GurventVantilator.Application.Extensions;
using GurventVantilator.Application.Validators;
using GurventVantilator.Infrastructure.Data;
using GurventVantilator.Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// DbContext kaydı
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddApplicationServices();

builder.Services.AddInfrastructureServices(builder.Configuration);

// Add services to the container.
builder.Services.AddControllersWithViews();

// FluentValidation entegrasyonu (yeni yöntem)
builder.Services.AddFluentValidationAutoValidation(options =>
{
    options.DisableDataAnnotationsValidation = true;
}).AddFluentValidationClientsideAdapters();

// Validatorların bulunduğu assembly’i tara
builder.Services.AddValidatorsFromAssemblyContaining<CompanyCreateViewModelValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<VersionInfoDtoValidator>();
// Add services to the container.
builder.Services.AddControllersWithViews();

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
