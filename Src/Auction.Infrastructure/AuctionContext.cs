using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.Infrastructure
{
    internal class AuctionContext : DbContext
    {
        internal virtual DbSet<Domain.Auction> Auctions { get; set; }

        internal virtual DbSet<Domain.AuctionItem> AuctionItems { get; set; }

        internal virtual DbSet<Domain.Bid> Bids { get; set; }

        internal virtual DbSet<IntegrationEventEntity> IntegrationEvents { get; set; }

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
