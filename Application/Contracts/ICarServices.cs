using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTOs;

namespace Application.Contracts
{
    public interface ICarServices
    {
        Task<List<CarForReturnDto>> GetCars(CarQueryDto carQueryDto);

        Task<List<CustomerForReturnDto>> GetCustomers(CustomerQueryDto customerQueryDto);

        Task<bool> SendCarStatus(CarStatusTransactionForPostDto carStatusTransactionForPostDto);
    }
}
