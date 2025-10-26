//using Microsoft.EntityFrameworkCore;
//using RoomMates.DAL;
//using RoomMates.DBContext;
//using Rotativa.AspNetCore;

//var builder = WebApplication.CreateBuilder(args);

//// ------------------------
//// 1️⃣ Add services BEFORE builder.Build()
//// ------------------------
//builder.Services.AddControllersWithViews();

//// Add DbContext (if you still use it elsewhere)
//builder.Services.AddDbContext<ConnetionDBContext>(options =>
//    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
//);

//// Add session and HttpContextAccessor
//builder.Services.AddSession();
//builder.Services.AddHttpContextAccessor();

//// ✅ FIXED: Register DataAccess correctly
//builder.Services.AddScoped<DataAccess>(sp =>
//    new DataAccess(builder.Configuration.GetConnectionString("DefaultConnection")));



//// Add this after app.UseStaticFiles();


//// ------------------------
//// 2️⃣ Build the app
//// ------------------------
//var app = builder.Build();

//// ------------------------
//// 3️⃣ Configure middleware AFTER builder.Build()
//// ------------------------
//if (!app.Environment.IsDevelopment())
//{
//    app.UseExceptionHandler("/Home/Error");
//    app.UseHsts();
//}

//app.UseHttpsRedirection();
//app.UseStaticFiles();

//app.UseRouting();

//// Session middleware
//app.UseSession();

//app.UseAuthorization();

//// Map default route
//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=Login}/{action=Login}/{id?}");

//app.Run();
using Microsoft.EntityFrameworkCore;
using RoomMates.DAL;
using RoomMates.DBContext;
using Rotativa.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// ------------------------
// 1️⃣ Add services BEFORE builder.Build()
// ------------------------

// Add MVC controllers with views
builder.Services.AddControllersWithViews();

// Add DbContext (if still used elsewhere)
builder.Services.AddDbContext<ConnetionDBContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);

// Add session and HttpContextAccessor
builder.Services.AddSession();
builder.Services.AddHttpContextAccessor();

// Register DataAccess with correct connection string
builder.Services.AddScoped<DataAccess>(sp =>
    new DataAccess(builder.Configuration.GetConnectionString("DefaultConnection"))
);

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

// ------------------------
// 4️⃣ Configure Rotativa
// ------------------------
// Make sure wkhtmltopdf.exe exists in wwwroot/Rotativa
 
// ------------------------
// 5️⃣ Map default route
// ------------------------
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Login}/{id?}"
);

app.Run();
