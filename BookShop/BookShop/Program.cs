﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using BookShop.Data;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<BookShopContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("BookShopContext") ?? throw new InvalidOperationException("Connection string 'BookShopContext' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
