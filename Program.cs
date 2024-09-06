using Store.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Store.Repository;
using Store.Models;

var builder = WebApplication.CreateBuilder(args);
//��������� ApiDbContext � ������������� PostgreSQL
builder.Services.AddDbContext<ApiDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultDbConnection")));
// ��������� Identity � ������������� ApiDbContext (��� ��������� ������� � �������������)
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
//��������� ��� ������
builder.Services.Configure<IdentityOptions>(option =>
{
    // ̳������� ������� ������ � 5 �������.
    option.Password.RequiredLength = 5;
    // ������ ���� �������� 1 ��������� ������ � ����� (������, ���� �� ������������).
    option.Password.RequiredUniqueChars = 1;
    // �� ����'������, ��� ������ ����� �����.
    option.Password.RequireDigit = false;
    // �� ����'������, ��� ������ ����� ����� �������� ������� (��� �����).
    option.Password.RequireLowercase = false;
    // �� ����'������, ��� ������ ����� ����� ��������� ������� (����� �����).
    option.Password.RequireUppercase = false;
    // �� ����'������, ��� ������ ����� ��������� ������� (����. !,@,#).
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
