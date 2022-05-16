using AutoMapper;
using Entities;
using Entities.Enums;

namespace API.Models.Dtos
{
    public class OrdersCreateDto
    {
        public OrderData Order { get; set; }
        
        public class OrderData
        {
            public long Id { get; set; }
            
            public OrderStatus Status { get; set; }
        }
    }

    public class OrdersCreateDtoProfile : Profile
    {
        public OrdersCreateDtoProfile()
        {
            CreateMap<Order, OrdersCreateDto.OrderData>();
        }
    }
}