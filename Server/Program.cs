using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Components.WebAssembly.Server;
using Server.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddControllersWithViews(); // for API + MVC views
builder.Services.AddRazorPages();           // for Blazor routing

// Add DbContext (SQLite)
var conn = builder.Configuration.GetConnectionString("DefaultConnection") ?? "Data Source=blog.db";
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(conn));

// Add CORS (for dev only)
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowDevClient", policy =>
    {
        policy.AllowAnyHeader()
              .AllowAnyMethod()
              .AllowAnyOrigin(); // ⚠️ only for dev
    });
});

var app = builder.Build();

// Seed data
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    await DummyDataLoader.EnsureSeedDataAsync(db);
}

app.UseCors("AllowDevClient");

if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();  // enable Blazor debugging
}
else
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

// 🧩 These 3 lines serve your Blazor WebAssembly frontend
app.UseBlazorFrameworkFiles(); // locate Blazor files
app.UseStaticFiles();          // serve CSS, JS, images, etc.

// Routing
app.UseRouting();

app.MapRazorPages();
app.MapControllers();

// 👇 This ensures any unknown route falls back to Blazor index.html
app.MapFallbackToFile("index.html");

app.Run();
