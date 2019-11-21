using System;
using System.Timers;
using Microsoft.AspNetCore.SignalR;
using SignalRHub.Hubs;

namespace SignalRHub.Services
{
    public class EventReceiverService
    {
        private readonly IHubContext<EventHub> _eventHub;

        public EventReceiverService(IHubContext<EventHub> eventHub)
        {
            _eventHub = eventHub;
            Init();
        }

        private void Init()
        {
        }
        public void StartReceive()
        {
            Console.WriteLine("Start receiving..........");
        }

       
    }
}