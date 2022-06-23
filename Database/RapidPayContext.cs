using Microsoft.EntityFrameworkCore;
using RapidPay.Models;
using System.Threading.Tasks;

namespace RapidPay.Database
{
    public class RapidPayContext : DbContext
    { 
        public DbSet<User> User { get; set; }
        public DbSet<Card> Card { get; set; }

        public DbSet<PaymentFee> PaymentsFee { get; set; }
        public RapidPayContext(DbContextOptions<RapidPayContext> options)
           : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>(entity =>
            {
                entity.HasKey(k => k.Id);
            });

            builder.Entity<Card>(entity =>
            {
                entity.HasKey(k => k.CardNumber);
                entity.Property(p => p.CardNumber).HasMaxLength(15);
            });

            builder.Entity<PaymentFee>(entity =>
            {
                entity.HasKey(k => k.Id); 
            });
        }
        public Task<int> SaveChangesAsync()
        {
            return base.SaveChangesAsync();
        }
    }
}
