using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Application.DTOs;
using Domain.Entities;
using Infrastructure.Data.Contracts;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Commands
{
    public class CarStatusCommandHandler : IRequestHandler<CarStatusTransactionForPostDto, bool>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CarStatusCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public Task<bool> Handle(CarStatusTransactionForPostDto request, CancellationToken cancellationToken)
        {
            if (request == null )
                return Task.FromResult(false);

            var car = _unitOfWork.CarRepository.Queryable().FirstOrDefault(t => t.Id == request.CarId);
            //No need to save  transaction only if new status = current status
            if (car == null || car.CurrentStatusId == request.StatusId)
                return Task.FromResult(false);

            car.CurrentStatusId = request.StatusId;

            // no need for using AutoMapper as mapping will use one time only :)
            var carStatusTransaction = new CarStatusTransaction
            {
                CarId = request.CarId,
                CreatedById = -1, //system
                CreatedDate = DateTime.Now,
                StatusId = request.StatusId
            };
            _unitOfWork.CarStatusTransactionRepository.Add(carStatusTransaction);

            _unitOfWork.Commit();
            return Task.FromResult(true);
        }
    }
}
