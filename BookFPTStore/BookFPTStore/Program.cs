using BookFPTStore.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//Adding DBContext Service
builder.Services.AddDbContext<FptbookstoreContext>(options => 
                options.UseSqlServer(builder.Configuration.
                GetConnectionString("DBConnection")));


builder.Services.AddIdentity<AppUserModel,IdentityRole>()
    .AddEntityFrameworkStores<FptbookstoreContext>().AddDefaultTokenProviders();

/*builder.Services.ConfigureApplicationCookie(op => op.LoginPath = "/UserAuthentication/Login");*/

builder.Services.Configure<IdentityOptions>(options =>
{
    // Password settings.
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequiredLength = 4;

    options.User.RequireUniqueEmail = true;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "Areas",
    pattern: "{area:exists}/{controller=Category}/{action=Index}/{id?}");

/*app.MapControllerRoute(
    name: "Areas",
    pattern: "{area:exists}/{controller=Book}/{action=Index}/{id?}");*/

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

/*app.MapControllerRoute(
    name: "account",
    pattern: "/account/{slug?}",
    defaults: "{controller=Home}/{action=Index}/{id?}");*/


app.Run();
