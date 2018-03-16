using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Auction.API.ReadModel;
using Auction.Infrastructure;
using Autofac;
using Autofac.Builder;
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

            builder.RegisterGeneric(typeof(Repository<>)).As(typeof(IRepository<>));

            builder.Register<IRepository<Domain.Auction>>(context =>
            {
                return new Repository<Domain.Auction>(context.Resolve<AuctionContext>());

            }).InstancePerLifetimeScope();

            builder.RegisterType<AuctionQueries>()
                .As<IAuctionQueries>()
                .InstancePerLifetimeScope();

            builder.RegisterType<AuctionUnitOfWork>()
                .As<IUnitOfWork>()
                .InstancePerLifetimeScope();
        }
    }
}
