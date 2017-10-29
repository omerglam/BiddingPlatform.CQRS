using System;
using System.Linq;
using System.Threading.Tasks;
using Infrastructure.DDD;
using Infrastructure.Persistence.EF;
using MediatR;

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


        public async Task Save(Domain.Auction aggregate) //TODO: distinguish between Add\Update on the generic repository operations
        {
            //Todo:
            // execute all domain events (scan the aggregate and publish with mediator)
            // save changes to DB (create CallContext under the API to make all changes + changes from the domain event handling to commit in one transaction)
            // (shared DbContext per lifetime scope)
            // publish integration events to the bus (use outbox pattern to persist event to db togther in the single transaction + 
            // + and have a background worker reading events and publishing?)

           var auctionRepository = _unitOfWork.GetRepository<Domain.Auction>();

           await auctionRepository.Add(aggregate);

            var eventsPublish = aggregate.Events.Select(async e => await _mediator.Publish(e));

            await Task.WhenAll(eventsPublish.ToArray());

            //TODO: clear events from aggegate?
           
            await _unitOfWork.SaveChanges();
           
        }

        public Task<Domain.Auction> Find(Guid id)
        {
            throw new NotImplementedException();
        }
    }


}
