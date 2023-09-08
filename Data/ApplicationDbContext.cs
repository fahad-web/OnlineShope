using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OnlineShope.Models;

namespace OnlineShope.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<Products> Pruducts { get; set; }
        public DbSet<SpacialTag> SpacialTags { get; set; }
    }
}