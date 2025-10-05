using Microsoft.EntityFrameworkCore;
using RoomMates.DBContext;

var builder = WebApplication.CreateBuilder(args);

// ------------------------
// 1️⃣ Add services BEFORE builder.Build()
// ------------------------
builder.Services.AddControllersWithViews();

// Add DbContext
builder.Services.AddDbContext<ConnetionDBContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);

// Add session and HttpContextAccessor
builder.Services.AddSession();
builder.Services.AddHttpContextAccessor();

// ------------------------
// 2️⃣ Build the app
// ------------------------
var app = builder.Build();

// ------------------------
// 3️⃣ Configure middleware AFTER builder.Build()
// ------------------------
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// Session middleware
app.UseSession();

app.UseAuthorization();

// Map default route
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Login}/{id?}");

app.Run();
