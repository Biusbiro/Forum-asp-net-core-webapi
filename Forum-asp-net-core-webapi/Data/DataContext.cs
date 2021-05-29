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
        public DbSet<Cathegory> Subcathegories { get; set; }
        public DbSet<Cathegory> Topic { get; set; }
        public DbSet<Cathegory> Post { get; set; }
        public DbSet<Cathegory> User { get; set; }
    }
}
