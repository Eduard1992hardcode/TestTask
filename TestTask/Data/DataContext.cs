using Microsoft.EntityFrameworkCore;
using TestTask.Models;

namespace TestTask.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }
        public DbSet<BalanceModel> Balances { get; set; }
        public DbSet<PaymentModel> Payments { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<BalanceModel>().HasIndex(a => a.Id).IsUnique();
            builder.Entity<PaymentModel>().HasIndex(a => a.Id).IsUnique();
        }
    }
}
