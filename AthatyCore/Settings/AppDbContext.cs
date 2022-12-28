using Microsoft.EntityFrameworkCore;
using AthatyCore.Entities;

namespace AthatyCore.Settings
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions opt): base(opt){}

        public DbSet<Item>? Items { get; set;}
        public DbSet<Product>? Products { get; set; }
        public DbSet<Category>? Categories { get; set; }
        public DbSet<AuthenticationRequest>? Users { get; set; }
    }
}
