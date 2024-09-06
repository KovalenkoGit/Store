using Store.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Store.Repository;
using Store.Models;

var builder = WebApplication.CreateBuilder(args);
//Реєстрація ApiDbContext з використанням PostgreSQL
builder.Services.AddDbContext<ApiDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultDbConnection")));
// Реєстрація Identity з використанням ApiDbContext (Для створення таблиць з користувачами)
builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<ApiDbContext>()
    .AddDefaultTokenProviders();

// Add services to the container.
builder.Services.AddControllersWithViews();
#if DEBUG
builder.Services.AddRazorPages().AddRazorRuntimeCompilation();
#endif
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IAccountRepository, AccountRepository>();
//Параметри для паролів
builder.Services.Configure<IdentityOptions>(option =>
{
    // Мінімальна довжина пароля — 5 символів.
    option.Password.RequiredLength = 5;
    // Вимога мати принаймні 1 унікальний символ у паролі (символ, який не повторюється).
    option.Password.RequiredUniqueChars = 1;
    // Не обов'язково, щоб пароль містив цифру.
    option.Password.RequireDigit = false;
    // Не обов'язково, щоб пароль містив літери нижнього регістру (малі літери).
    option.Password.RequireLowercase = false;
    // Не обов'язково, щоб пароль містив літери верхнього регістру (великі літери).
    option.Password.RequireUppercase = false;
    // Не обов'язково, щоб пароль містив спеціальні символи (напр. !,@,#).
    option.Password.RequireNonAlphanumeric = false;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.UseAuthentication();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
