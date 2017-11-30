using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Auction.Infrastructure;
using Autofac;
using Infrastructure.DDD;
using Infrastructure.Persistence.EF;

namespace Auction.API.Infrastructure
{
    class AuctionApiModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AuctionRepository>()
                .As<IAggregateRepository<Domain.Auction>>()
                .InstancePerLifetimeScope();

            builder.RegisterType<AuctionUnitOfWork>()
                .As<IUnitOfWork>()
                .InstancePerLifetimeScope();
        }
    }
}
