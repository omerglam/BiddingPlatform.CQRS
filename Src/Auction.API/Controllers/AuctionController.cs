using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Auction.API.Commands;
using MediatR;

namespace Auction.API.Controllers
{
    [Route("/Auction")]
    public class AuctionController : ApiController
    {
        private readonly IMediator _mediator;

        public AuctionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("/{auctionId}/item/{itemId}/bid")]
        public async Task AddBidToAuctionItem([FromUri] Guid auctionId, [FromUri] int itemId, BidRequest bidRequest)
        {
            //TODO: get ambient user info

            var bidCommand = new AddBidCommand("TODO: GET AMBIENT USER INFO",auctionId, itemId,bidRequest.Amount, DateTime.UtcNow);

            //Todo: dispatch command.
            await _mediator.Send(bidCommand);

            //Todo: read from read model the command results. {bidder,item,timestamp as key to lookup}

        }
    }

    public class BidRequest
    {
        public decimal Amount { get; set; }
    }
}
