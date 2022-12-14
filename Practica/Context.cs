using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Models;

namespace WpfApp1
{
    public class Context : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<StatusOrder> StatusOrders { get; set; }
        public DbSet<Reserve> Reserves { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Place> Places { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Dish> Dishs { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(x => 
            {
                x.Property(x => x.Contract).IsRequired(false);
                x.Property(x => x.Photo).IsRequired(false);
            });
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data source=(localdb)\mssqllocaldb;Database=EF2;Trusted_Connection=True");
        }
    }
}
