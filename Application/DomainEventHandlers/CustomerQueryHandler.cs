using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.DTOs;
using AutoMapper;
using Domain.Entities;
using Infrastructure.Data.Contracts;
using MediatR;

namespace Application.DomainEventHandlers
{

    public class CustomerQueryHandler : IRequestHandler<CustomerQueryDto, List<CustomerForReturnDto>>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public CustomerQueryHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public Task<List<CustomerForReturnDto>> Handle(CustomerQueryDto request, CancellationToken cancellationToken)
        {
            //No need for pagination 

            //var pageSize = request.PageSize ?? 10;
            //var pageIndex = request.Page ?? 0;
            //var customers = _unitOfWork.CustomerRepository.Queryable()
            //    .Skip(pageIndex * pageSize)
            //    .Take(pageSize)
            //    .ToList();
            //return Task.Run(() => _mapper.Map<List<Customer>, List<CustomerForReturnDto>>(customers));

            var customers = _unitOfWork.CustomerRepository.Queryable().ToList();
            return Task.Run(() => _mapper.Map<List<Customer>, List<CustomerForReturnDto>>(customers));

        }
    }
}
