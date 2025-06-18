using Microsoft.ILP.Web.Settings;
using Microsoft.ILP.Web.Services;


var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddControllersWithViews();
builder.Services.AddSession(); // ✅ Enable session

// Register config
builder.Services.Configure<ServiceEndpoints>(
    builder.Configuration.GetSection("ServiceEndpoints"));

builder.Services.AddHttpClient();
builder.Services.AddScoped<IProductService, ProductService>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseSession(); // ✅ Add this
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
