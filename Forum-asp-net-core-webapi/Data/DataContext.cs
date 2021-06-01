using Forum_asp_net_core_webapi.Models;
using Microsoft.EntityFrameworkCore;

namespace Forum_asp_net_core_webapi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Cathegory> Cathegories { get; set; }
        public DbSet<Subcathegory> Subcathegories { get; set; }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<User> User { get; set; }
    }
}
