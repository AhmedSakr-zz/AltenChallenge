using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Contracts;
using Application.DTOs;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Services
{
    public class CarServices : ICarServices
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public CarServices(IMediator _mediator, IMapper mapper)
        {
            this._mediator = _mediator;
            _mapper = mapper;
        }

        public async Task<List<CarForReturnDto>> GetCars(CarQueryDto carQueryDto)
        {
            var cars = await _mediator.Send(carQueryDto);
            return _mapper.Map<List<Car>, List<CarForReturnDto>>(cars);
        }

        public async Task<List<CustomerForReturnDto>> GetCustomers(CustomerQueryDto customerQueryDto)
        {
            return await _mediator.Send(customerQueryDto);
        }

        public async Task<bool> SendCarStatus(CarStatusTransactionForPostDto carStatusTransactionForPostDto)
        {
            if (carStatusTransactionForPostDto == null ||
                carStatusTransactionForPostDto.StatusId == 0 ||
                carStatusTransactionForPostDto.CarId == 0)
                return false;

            var result = await _mediator.Send(carStatusTransactionForPostDto);

            if (!result) return false;

            var newStatus = new CarStatusTransactionForReturnDto
            {
                CarId = carStatusTransactionForPostDto.CarId,
                StatusId = carStatusTransactionForPostDto.StatusId
            };

            await _mediator.Publish(newStatus); //or use RabbitMQ to send message to signalR receiver
            return true;
        }

    }
}
