using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Auction.Api.Controllers.Model;
using Auction.API.Commands;
using Auction.API.Controllers.Model;
using Auction.Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Auction.API.Controllers
{
    [Route("/auctions")]
    public class AuctionController : Controller
    {
        private readonly IMediator _mediator;

        public AuctionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost()]
        public async Task Create(CreateAuctionRequest createRequest)
        {
            //TODO: id assignemnt of scoped auction item - responsability?

            var auctionItems = new Domain.AuctionItem[createRequest.AuctionItems.Length];

            for (int i = 0; i < createRequest.AuctionItems.Length; i++) //Mapping
            {
                var requestAuctionItem = createRequest.AuctionItems[i];

                auctionItems[i] = new Domain.AuctionItem(i, requestAuctionItem.Name, requestAuctionItem.Description, requestAuctionItem.ReservedPrice);
            }

            await _mediator.Send(new CreateAuctionCommand(createRequest.Name, auctionItems));
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
