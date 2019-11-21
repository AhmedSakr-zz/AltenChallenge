using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Data.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Services
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(DbContext context)
        {
            _context = context;
        }

        private readonly DbContext _context;
        private ICustomerRepository _customerRepository;
        private ICarRepository _carRepository;
        private ICarStatusRepository _carStatusRepository;
        private ICarStatusTransactionRepository _carStatusTransactionRepository;
        private ILogDataRepository _logDataRepository;

        public ICustomerRepository CustomerRepository => _customerRepository ?? (_customerRepository = new CustomerRepository(_context));
        public ICarRepository CarRepository => _carRepository ?? (_carRepository = new CarRepository(_context));
        public ICarStatusRepository CarStatusRepository => _carStatusRepository ?? (_carStatusRepository = new CarStatusRepository(_context));
        public ICarStatusTransactionRepository CarStatusTransactionRepository => _carStatusTransactionRepository ?? (_carStatusTransactionRepository = new CarStatusTransactionRepository(_context));
        public ILogDataRepository LogDataRepository =>_logDataRepository ?? (_logDataRepository = new LogDataRepository(_context));

        public void Dispose()
        {
            _context?.Dispose();
        }
        public int Commit()
        {
            return _context.SaveChanges();
        }
        public Task<int> CommitAsync()
        {
            return _context.SaveChangesAsync();
        }
    }
}
