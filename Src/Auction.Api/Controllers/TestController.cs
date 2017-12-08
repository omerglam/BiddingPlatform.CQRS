using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Auction.Infrastructure;


namespace Auction.API.Controllers
{
    [Route("Test")]
    public class TestController : Controller
    {
        private readonly IMediator _mediator;
        private readonly AuctionContext con;

        public TestController(IMediator mediator, AuctionContext context)
        {
            _mediator = mediator;
            con = context;
        }


        [HttpGet]
        public Task Test()
        {
            return Task.CompletedTask;
        }

    }
}