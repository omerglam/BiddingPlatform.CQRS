using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Persistence.EF;

namespace Auction.Infrastructure
{
    public class AuctionUnitOfWork : IUnitOfWork
    {
        private readonly AuctionContext _context;

        public AuctionUnitOfWork(AuctionContext context)
        {
            _context = context;
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }

        public IRepository<T> GetRepository<T>() where T : class
        {
            return new Repository<T>(_context);
        }
    }
}
