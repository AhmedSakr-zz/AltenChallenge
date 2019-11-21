using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Application.Contracts;
using Application.DTOs;

namespace Application.Services
{
    public class FakeSendCarStatusServices : IFakeSendCarStatusServices
    {
        private readonly ICarServices _carServices;

        public FakeSendCarStatusServices(ICarServices carServices)
        {
            _carServices = carServices;
        }

        /// <summary>
        /// fake implementation for get car status every 1 minute
        /// </summary>
        /// <returns></returns>
        public async Task<bool> Start()
        {
            while (true)
            {
                //Ping car1 = new Ping();
                //PingReply result = car1.Send("192.168.2.18");

                var random = new Random();
                for (var i = 1; i <= 7; i++) // Car Ids -- in production MUST get these ids from database :)
                {
                    var carStatusTransactionForPostDto = new CarStatusTransactionForPostDto
                    {
                        CarId = i,
                        StatusId = random.Next(1, 3)
                    };

                    await _carServices.SendCarStatus(carStatusTransactionForPostDto);
                }
                //hold for 1 minute
                Thread.Sleep(60 * 1000);
            }
            return true;
        }
    }
}
