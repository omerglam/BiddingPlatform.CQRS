using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Auction.Domain;
using Infrastructure.DDD;
using Infrastructure.Persistence.EF;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Auction.Infrastructure
{
    public class AuctionRepository : IAggregateRepository<Domain.Auction>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMediator _mediator;

        //Todo: EF repository/unit of work implementation

        public AuctionRepository(IUnitOfWork unitOfWork, IMediator mediator)
        {
            _unitOfWork = unitOfWork;
            _mediator = mediator;
        }


        public async Task Add(Domain.Auction aggregate) //TODO: distinguish between Add\Update on the generic repository operations
        {
            //Todo:
            // execute all domain events (scan the aggregate and publish with mediator)
            // save changes to DB (create CallContext under the API to make all changes + changes from the domain event handling to commit in one transaction)
            // (shared DbContext per lifetime scope)
            // publish integration events to the bus (use outbox pattern to persist event to db togther in the single transaction + 
            // + and have a background worker reading events and publishing?)

            await Save(async (repo, agg) => await repo.Add(agg), aggregate);
        }

        public async Task Update(Domain.Auction aggregate)
        {
          await Save(async (repo,agg) => await repo.Modify(agg), aggregate );
        }

        private async Task Save(Func<IRepository<Domain.Auction>,Domain.Auction,Task> repositoryOperation, Domain.Auction aggregate)
        {
            var repository = _unitOfWork.GetRepository<Domain.Auction>();

            await repositoryOperation(repository, aggregate);

            var eventsPublishTasks = aggregate.Events.Select(async e => await _mediator.Publish(e)).ToArray();

            await Task.WhenAll(eventsPublishTasks);

            await _unitOfWork.SaveChanges();
        }

        public async Task<Domain.Auction> Find(Guid id) //TODO: check this works with the includes\ThenIncludes
        {
            var repo = _unitOfWork.GetRepository<Domain.Auction>();

           return await repo.Get(auction => auction.Id == id,
                                           entity => entity.Include(e => e.Items)
                                            .ThenInclude(a => a.Bids));
        }
    }


}
