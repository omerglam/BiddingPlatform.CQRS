﻿using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Auction.Domain;
using Auction.Infrastructure.EntitiesConfigurations;
using Infrastructure.Persistence.EF;
using Microsoft.EntityFrameworkCore;

namespace Auction.Infrastructure
{
    public class AuctionContext : DbContext
    {
        internal virtual DbSet<Domain.Auction> Auctions { get; set; }

        internal virtual DbSet<AuctionItem> AuctionItems { get; set; }

        internal virtual DbSet<Bid> Bids { get; set; }

        internal virtual DbSet<IntegrationEventEntity> IntegrationEvents { get; set; }

        public AuctionContext(DbContextOptions<AuctionContext> contextOptions ) :base(contextOptions)
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           // optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["Auction"].ConnectionString);

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AuctionEntityConfiguration());
            modelBuilder.ApplyConfiguration(new AuctionItemEntityConfiguration());
            modelBuilder.ApplyConfiguration(new BidEntityConfiguration());
            modelBuilder.ApplyConfiguration(new IntegrationEventEntityConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
