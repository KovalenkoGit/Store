using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Store.Models;

namespace Store.Data
{
    public class ApiDbContext : IdentityDbContext<ApplicationUser>
    {

        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
        {

        }
        public DbSet<Product> Product { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<ProductImage> ProductImage { get; set; }
    }
}
