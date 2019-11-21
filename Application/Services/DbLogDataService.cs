using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Contracts;
using Domain.Entities;
using Infrastructure.Data.Contracts;

namespace Application.Services
{
    public class DbLogDataService:IDBLogService
    {
        private readonly IUnitOfWork _unitOfWork;

        public DbLogDataService( IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void LogData(string logType, string logMessage)
        {
            var logData = new LogData
            {
                LogType = logType,
                LogMessage = logMessage
            };
            _unitOfWork.LogDataRepository.Add(logData);
            _unitOfWork.Commit();
        }
    }
}
