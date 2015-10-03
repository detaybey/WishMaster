using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WishMaster.Service.Entities
{
    public class WishMasterDataContext : DbContext
    {
        public WishMasterDataContext()
            : base("wishmaster")
        {

        }

        public virtual DbSet<Card> Cards { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<FraudLog> FraudLogs { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Transaction> Transactions { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("public");
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<User>()
                        .HasMany(e => e.Products)
                        .WithRequired(e => e.Seller)
                        .WillCascadeOnDelete(true);

            modelBuilder.Entity<User>()
                     .HasMany(e => e.Cards)
                     .WithRequired(e => e.Owner)
                     .WillCascadeOnDelete(true);

            modelBuilder.Entity<User>()
                        .HasMany(e => e.Orders)
                        .WithRequired(e => e.Seller)
                        .WillCascadeOnDelete(true);

            modelBuilder.Entity<User>()
                    .HasMany(e => e.Scores)
                    .WithRequired(e => e.User)
                    .WillCascadeOnDelete(true);

            modelBuilder.Entity<Product>()
                     .HasMany(e => e.Orders)
                     .WithRequired(e => e.Product)
                     .WillCascadeOnDelete(true);

            modelBuilder.Entity<Category>()
                     .HasMany(e => e.Products)
                     .WithRequired(e => e.Category)
                     .WillCascadeOnDelete(true);

            modelBuilder.Entity<Order>()
                   .HasMany(e => e.Transactions)
                   .WithRequired(e => e.Order)
                   .WillCascadeOnDelete(true);

            modelBuilder.Entity<Card>()
                   .HasMany(e => e.Transactions)
                   .WithRequired(e => e.Card)
                   .WillCascadeOnDelete(true);

            modelBuilder.Entity<Card>()
                  .HasMany(e => e.FraudLogs)
                  .WithRequired(e => e.Card)
                  .WillCascadeOnDelete(true);

        }
    }
}
