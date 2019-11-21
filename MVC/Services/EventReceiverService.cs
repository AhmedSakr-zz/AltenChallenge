using System;
using Microsoft.AspNetCore.SignalR;
using ui.Hubs;

namespace ui.Services
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