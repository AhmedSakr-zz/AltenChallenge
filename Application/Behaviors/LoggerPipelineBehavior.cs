using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Contracts;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Behaviors
{
    public class LoggerPipelineBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly ILogger<LoggerPipelineBehavior<TRequest, TResponse>> _logger;
        private readonly IDBLogService _dbLogService;

        public LoggerPipelineBehavior(ILogger<LoggerPipelineBehavior<TRequest, TResponse>> logger,IDBLogService dbLogService)
        {
            _logger = logger;
            _dbLogService = dbLogService;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            _logger.LogInformation($"Handling {typeof(TRequest).Name}");
            var logMessage = $"Handling {typeof(TRequest).Name}";
            var response = await next();
            _logger.LogInformation($"Handled {typeof(TResponse).Name}");
            _logger.LogInformation($"Handling Time {DateTime.Now}");

            logMessage += $" => Handled {typeof(TResponse).Name}" + DateTime.Now;
            //Log to database
            _dbLogService.LogData("Log", logMessage);

            return response;
        }


    }
}
