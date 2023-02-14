using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ManageOrders00.Data;
using ManageOrders00.Models;
using MvcMovie.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<ManageOrders00Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ManageOrders00Context") ?? throw new InvalidOperationException("Connection string 'ManageOrders00Context' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();




var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    SetData.Initialize(services);
}


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
  
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Orders}/{action=Index}/{id?}");

app.Run();


