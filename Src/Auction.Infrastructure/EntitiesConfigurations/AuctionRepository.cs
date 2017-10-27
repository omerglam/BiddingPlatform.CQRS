﻿using System;
using System.Threading.Tasks;
using Infrastructure.DDD;

namespace Auction.Infrastructure.EntitiesConfigurations
{
    public class AuctionRepository : IAggregateRepository<Domain.Auction>
    {
        //Todo: EF repository/unit of work implementation

        public Task Save(Domain.Auction aggregate) //TODO: distinguish between Add\Update on the generic repository operations
        {
            //Todo:
            // execute all domain events (scan the aggregate and publish with mediator)
            // save changes to DB (create CallContext under the API to make all changes + changes from the domain event handling to commit in one transaction)
            // (shared DbContext per lifetime scope)
            // publish integration events to the bus (use outbox pattern to persist event to db togther in the single transaction + 
            // + and have a background worker reading events and publishing?)


            throw new NotImplementedException();
        }

        public Task<Domain.Auction> Find(Guid id)
        {
            throw new NotImplementedException();
        }
    }


}