using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.EF
{
    public interface IUnitOfWork
    {
        Task SaveChanges();

        IRepository<T> GetRepository<T>() where T : class;
    }
}
