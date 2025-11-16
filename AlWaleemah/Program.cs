using AlWaleemah.Data;
using AlWaleemah.interfaces;
using AlWaleemah.Repository;
using AlWaleemah.Repository.Base;
using AlWaleemah.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IRepoProduct, RepoProduct>();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<ICheckoutService, CheckoutService>();
builder.Services.AddScoped<ICartItemRepository, CartItemRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();




// Get the connection string from appsettings.json

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30); // Set session timeout
    options.Cookie.HttpOnly = true; // Make the session cookie HTTP only
    options.Cookie.IsEssential = true; // Make the session cookie essential
});


//// Register the DbContext with the connection string
builder.Services.AddDbContext<Applicationdbcontext>(options =>
options.UseLazyLoadingProxies()
    .UseSqlServer(connectionString));

//builder.Services.AddDbContext<Applicationdbcontext>(options =>
//options.UseLazyLoadingProxies().
//    UseSqlServer(conectionString));


// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();





// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.MapControllers(); // مهم للـ API attribute routing

app.UseHttpsRedirection();
app.UseStaticFiles();



app.UseRouting();
app.UseSession();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
 //   pattern: "{controller=Account}/{action=Login}/{id?}");
    pattern: "{controller=HomePage}/{action=Index}/{id?}");

app.Run();
