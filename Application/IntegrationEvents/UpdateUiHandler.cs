using System;
using System.Security.Cryptography.X509Certificates;
using Application.DTOs;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;


namespace Application.IntegrationEvents
{
    public class UpdateUiHandler : INotificationHandler<CarStatusTransactionForReturnDto>
    {
        private readonly IConfiguration _configuration;

        public UpdateUiHandler(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public Task Handle(CarStatusTransactionForReturnDto notification, CancellationToken cancellationToken)
        {
            //update ui using signalR or Rabbitmq

            if(notification ==null)
                return Task.FromResult(false);

            if (string.IsNullOrEmpty(_configuration["SignalRHub"]))
                return Task.FromResult(false);


            //signalR
            var connection = new HubConnectionBuilder()
                .WithUrl(_configuration["SignalRHub"])
                .Build();

            connection.StartAsync(cancellationToken);

            connection.InvokeAsync("SendMessage", "",
                JsonConvert.SerializeObject(notification),
                cancellationToken: cancellationToken);

            connection.Closed += async (error) =>
            {
                await Task.Delay(3 * 1000);
                await connection.StartAsync();
            };
            return Task.FromResult(true);
        }
    }
}
