using Microsoft.AspNetCore.Routing;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Middleware setup
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// --- Advanced Routing Setup ---

// Complex route: /Products/{category}/{id}
app.MapControllerRoute(
    name: "products",
    pattern: "Products/{category}/{id:int}",
    defaults: new { controller = "Products", action = "Details" });

// Complex route: /Users/{username}/Orders
app.MapControllerRoute(
    name: "userOrders",
    pattern: "Users/{username}/Orders",
    defaults: new { controller = "Users", action = "Orders" });

// Route with built-in GUID constraint: /Orders/{orderId}
app.MapControllerRoute(
    name: "ordersByGuid",
    pattern: "Orders/{orderId:guid}",
    defaults: new { controller = "Orders", action = "Details" });

// Dynamic route for dashboard based on user role
app.MapControllerRoute(
    name: "dashboard",
    pattern: "Dashboard",
    defaults: new { controller = "Dashboard", action = "Index" });

// Default route
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
