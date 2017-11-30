using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Auction.API.Commands;
using Auction.API.Commands.Handlers;
using Auction.API.Events.Handlers;
using Auction.Events;
using Autofac;
using MediatR;

namespace Auction.API.Infrastructure
{
    class MediatRModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {

            builder
                .RegisterType<Mediator>()
                .As<IMediator>()
                .InstancePerLifetimeScope();

            //builder.RegisterType<AuctionCommandHandler>().As(typeof(IAsyncRequestHandler<>)).InstancePerDependency();
            builder.RegisterAssemblyTypes(typeof(AddBidCommand).Assembly).AsClosedTypesOf(typeof(IAsyncRequestHandler<>)).InstancePerDependency();
            //builder.RegisterType<DomainEventToIntegrationEventHandler>().As(typeof(IAsyncNotificationHandler<>)).InstancePerDependency();
            builder.RegisterAssemblyTypes(typeof(DomainEventToIntegrationEventHandler).Assembly).AsClosedTypesOf(typeof(IAsyncNotificationHandler<>)).InstancePerDependency();

            builder.RegisterType<AuctionCreated>().As<INotification>();
            builder.RegisterType<BidAccepted>().As<INotification>();
            builder.RegisterType<BidRejected>().As<INotification>();

            builder.Register<SingleInstanceFactory>(context =>
            {
                var componentContext = context.Resolve<IComponentContext>();
                return t => { object o; return componentContext.TryResolve(t, out o) ? o : null; };
            });

            builder.Register<MultiInstanceFactory>(context =>
            {
                var componentContext = context.Resolve<IComponentContext>();

                return t =>
                {
                    var resolved = (IEnumerable<object>)componentContext.Resolve(typeof(IEnumerable<>).MakeGenericType(t));
                    return resolved;
                };
            });
        }
    }
}
