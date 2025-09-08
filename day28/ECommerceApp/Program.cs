app.MapControllerRoute(
    name: "productDetails",
    pattern: "Products/{category}/{id:int}",
    defaults: new { controller = "Products", action = "Details" });
