using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Application.DTOs;
using AutoMapper;
using Domain.Entities;
using Infrastructure.Data.Contracts;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.DomainEventHandlers
{
    public class CarQueryHandler : IRequestHandler<CarQueryDto, List<Car>>
    {
        
        private readonly IUnitOfWork _unitOfWork;

        public CarQueryHandler( IUnitOfWork unitOfWork)
        {
            
            _unitOfWork = unitOfWork;
        }

        public Task<List<Car>> Handle(CarQueryDto request, CancellationToken cancellationToken)
        {
            var carsList = _unitOfWork.CarRepository.Queryable()
                .Where(t =>
                (t.CustomerId == request.CustomerId || request.CustomerId == 0) &&
                (t.CurrentStatusId == request.StatusId || request.StatusId == 0))
                .Include(t => t.Customer)
                .Include(t => t.CarStatus)
                .ToList();
            return Task.Run(() => carsList);
            //return Task.Run(() => _mapper.Map<List<Car>, List<CarForReturnDto>>(carsList));
        }
    }
}
