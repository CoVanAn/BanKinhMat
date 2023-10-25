
using BanKinhMat.Models;
using BanKinhMat.Repository;
using Microsoft.EntityFrameworkCore;

WebApplicationBuilder builder = NewMethod(args);
// Add services to the container.

var connectionString = builder.Configuration.GetConnectionString("SQLBanKinhMatContext");
builder.Services.AddDbContext<SQLBanKinhMatContext>(x => x.UseSqlServer(connectionString));

//builder.Services.AddDbContext<SQLBanKinhMatContext>(options => options
//.UseSqlServer(builder.Configuration.GetConnectionString("SQLBanKinhMatContext")));

builder.Services.AddControllersWithViews();
builder.Services.AddScoped<ILoaiSpRepository, LoaiSpRepository>();


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

static WebApplicationBuilder NewMethod(string[] args)
{
    return WebApplication.CreateBuilder(args);
}