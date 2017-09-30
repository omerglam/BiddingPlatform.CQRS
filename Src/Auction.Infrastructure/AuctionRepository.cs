using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure;
using Infrastructure.DDD;
using Infrastructure.Persistence.EF;

namespace Auction.Infrastructure
{
    public class AuctionRepository : IAggregateRepository<Domain.Auction>
    {
        //Todo: EF repository/unit of work implementation

        public Task Save(Domain.Auction aggregate)
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
