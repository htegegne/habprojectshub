using EventManagement.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
//string connString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<EventDbContext>(options => options.UseSqlServer(
   builder.Configuration.GetConnectionString("DefaultConnection")/*,
        sqlOptions => sqlOptions.EnableRetryOnFailure()*/));

// Register the API client first
/*builder.Services.AddHttpClient<IEventApiClient, EventApiClient>(client =>
{
    client.BaseAddress = new Uri("https://localhost:5002/api/"); // Base URL of your API
});*/
builder.Services.AddScoped<IEventRepository, DbEventRepository>();

/*builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.Cookie.Name = ".AppAuthentication"; // Same cookie name as in AppUserManager
        options.Cookie.SameSite = SameSiteMode.Lax;
        options.Cookie.HttpOnly = true;
        options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
        options.LoginPath = "/AppUserManager/Account/Login"; // Point to AppUserManager's login page
        options.AccessDeniedPath = "/Account/AccessDenied";
        options.SlidingExpiration = true;
        options.ExpireTimeSpan = TimeSpan.FromMinutes(60);
    });

builder.Services.AddAuthorization(); */// Add authorization services
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    //app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();


app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "eventmanagement",
    pattern: "{controller=Events}/{action=Index}/{id?}"); 

app.Run();
