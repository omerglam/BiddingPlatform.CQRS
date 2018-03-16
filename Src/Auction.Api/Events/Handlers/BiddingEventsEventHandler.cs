using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Auction.API.Events.IntegrationEvents;
using Auction.Events;
using MediatR;

namespace Auction.API.Events.Handlers
{
    public class BiddingEventsEventHandler : IAsyncNotificationHandler<BidAccepted>
    {
        public Task Handle(BidAccepted bidAcceptedNotification)
        {
            var bidAddedEvent = new BidAddedIntegrationEvent(bidAcceptedNotification.SourceId, bidAcceptedNotification.ItemId,bidAcceptedNotification.Bidder,bidAcceptedNotification.Amount);

            //Todo: store the event in the events table (using the events dbcontext) as part of the transaction, a background worker will dispatch the message later. use IHostedServices


            return Task.CompletedTask;
        }
    }
}
