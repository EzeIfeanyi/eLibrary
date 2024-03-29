using eLibrary;
using eLibrary.Data;
using eLibrary.Models.Entities;
using eLibrary.Services;
using eLibrary.Services.IServices;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddAutoMapper(typeof(MapperProfile));

builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<IMessanger, EmailMessanger>();
builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddHttpClient();

builder.Services.AddDbContext<eLibraryDbContext>( options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
});

builder.Services.AddIdentity<User, IdentityRole>()
    .AddEntityFrameworkStores<eLibraryDbContext>().AddDefaultTokenProviders();

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
