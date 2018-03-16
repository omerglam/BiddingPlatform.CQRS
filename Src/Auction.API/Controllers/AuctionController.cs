using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Auction.Api.Controllers.Model;
using Auction.Api.ReadModel.Model;
using Auction.API.Commands;
using Auction.API.Controllers.Model;
using Auction.API.ReadModel;
using Auction.Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Auction.API.Controllers
{
    [Route("/auctions")]
    public class AuctionController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IAuctionQueries _auctionQueries;

        //TODO: graphql for read, Rest endpoints for write operations?

        public AuctionController(IMediator mediator, IAuctionQueries auctionQueries)
        {
            _mediator = mediator;
            _auctionQueries = auctionQueries;
        }

        [HttpGet]
        public async Task<AuctionHighLevelView[]> Get()
        {
            return await _auctionQueries.GetAuctionsHighLevelView();
        }

        [HttpPost]
        public async Task Create([FromBody]CreateAuctionRequest createRequest)
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
    }
}
