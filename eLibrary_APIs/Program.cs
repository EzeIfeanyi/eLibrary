using eLibrary_APIs.DataAccess;
using eLibrary_APIs.DataAccess.Repo;
using eLibrary_APIs.DataAccess.Services;
using eLibrary_APIs.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<ApiDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
});

builder.Services.AddScoped<IItemRepository<Book>, ItemRepository<Book>>();
builder.Services.AddScoped<IItemRepository<BookCategory>, ItemRepository<BookCategory>>();
builder.Services.AddScoped<IItemRepository<Category>, ItemRepository<Category>>();
builder.Services.AddScoped<IItemRepository<Review>, ItemRepository<Review>>();
builder.Services.AddScoped<IItemRepository<Rating>, ItemRepository<Rating>>();
builder.Services.AddScoped<IBookService, BookService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
