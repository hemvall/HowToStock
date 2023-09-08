using HowToStock.Models;
using Microsoft.EntityFrameworkCore;

namespace howtostock_api.Context
{
    public class HowToStockContext : DbContext
    {
        public DbSet<User>? Users { get; set; }
        public DbSet<Color>? Color { get; set; }
        public DbSet<Items>? Item { get; set; }
        public DbSet<ItemType>? ItemType { get; set; }
        public DbSet<Language>? Languages { get; set; }
        public DbSet<Marketplace>? Marketplace { get; set; }
        public DbSet<Size>? Size { get; set; }
        public DbSet<State>? State { get; set; }
        public DbSet<Subscription>? Subscriptions { get; set; }

        public HowToStockContext(DbContextOptions<HowToStockContext> options) : base(options)
        {
        }
    }
}