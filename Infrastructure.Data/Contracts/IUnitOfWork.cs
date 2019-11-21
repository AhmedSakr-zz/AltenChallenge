using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Contracts
{
    public interface IUnitOfWork : IDisposable
    {
        ICustomerRepository CustomerRepository { get; }
        ICarRepository CarRepository { get; }
        ICarStatusRepository CarStatusRepository { get; }
        ICarStatusTransactionRepository CarStatusTransactionRepository { get; }
        ILogDataRepository LogDataRepository { get; }

        int Commit();
        Task<int> CommitAsync();
    }
}
