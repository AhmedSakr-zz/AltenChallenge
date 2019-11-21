using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts
{
    public interface IDBLogService
    {
        void LogData(string logType, string logMessage);
    }
}
