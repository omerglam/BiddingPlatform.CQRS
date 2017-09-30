using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.Infrastructure
{
    public class AuctionContext : DbContext
    {
        public virtual DbSet<Domain.Auction> Auction { get; set; }
        public virtual DbSet<EventEntity> IntegrationEvents { get; set; }

        public AuctionContext() : base("Auction")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<AuctionContext, Migrations.Configuration>());

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AuctionEntityConfiguration());
            modelBuilder.Configurations.Add(new IntegrationEventEntityConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
