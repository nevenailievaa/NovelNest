using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NovelNest.ModelBinders;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplicationDbContext(builder.Configuration);
builder.Services.AddApplicationIdentity(builder.Configuration);

builder.Services.AddControllersWithViews(options =>
{
    options.ModelBinderProviders.Insert(0, new DecimalModelBinderProvider());
    options.Filters.Add<AutoValidateAntiforgeryTokenAttribute>();
});

builder.Services.AddApplicationServices();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error/500");
    app.UseStatusCodePagesWithRedirects("/Home/Error?statusCode={0}");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "Book Details",
        pattern: "/Book/Details/{id}/{information}",
        defaults: new { Controller = "Book", Action = "Details" }
        );
    endpoints.MapControllerRoute(
        name: "Article Details",
        pattern: "/Article/Details/{id}/{information}",
        defaults: new { Controller = "Article", Action = "Details" }
        );
    endpoints.MapControllerRoute(
        name: "Event Details",
        pattern: "/Event/Details/{id}/{information}",
        defaults: new { Controller = "Event", Action = "Details" }
        );
    endpoints.MapControllerRoute(
        name: "BookStore Details",
        pattern: "/BookStore/Details/{id}/{information}",
        defaults: new { Controller = "BookStore", Action = "Details" }
        );
    endpoints.MapDefaultControllerRoute();
    endpoints.MapRazorPages();
});

await app.RunAsync();