using System;
using System.Threading.Tasks;
using Auction.Api.Controllers.Model;
using Auction.API.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Auction.API.Controllers
{
    [Route("/auctions")]
    public class BiddingController : Controller
    {
        private IMediator _mediator;

        public BiddingController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("/{auctionId}/item/{itemId}/bid")]
        //[Route("/{auctionId}/item/{itemId}/bid")]
        public async Task AddBidToAuctionItem(/*[FromUri]*/ string auctionId, /*[FromUri]*/ int itemId, [FromBody]BidRequest bidRequest)
        {
            //TODO: get ambient user info

            var bidCommand = new AddBidCommand("TODO: GET AMBIENT USER INFO", Guid.Parse(auctionId), itemId, bidRequest.Amount, DateTime.UtcNow);

            //Todo: dispatch command.
            await _mediator.Send(bidCommand);

            //Todo: read from read model the command results. {bidder,item,timestamp as key to lookup}

        }
    }
}