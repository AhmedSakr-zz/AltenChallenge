using Application.DTOs;
using AutoMapper;
using Domain.Entities;

namespace Microservice.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Customer, CustomerForReturnDto>().ReverseMap();

            CreateMap<Car, CarForReturnDto>()
                .ForMember(t=>t.CarId,
                    opt=>opt.MapFrom(s=>s.Id))
                .ForMember(t => t.CustomerName,
                    opt => opt.MapFrom(s => s.Customer.FullName))
                .ForMember(t=>t.StatusId,
                    opt=>opt.MapFrom(s=>s.CarStatus.Id))
                .ForMember(t => t.CustomerAddress,
                    opt => opt.MapFrom(s => s.Customer.Address))
                .ForMember(t => t.Status,
                    opt => opt.MapFrom(s => s.CarStatus.Name));

        }
    }
}
