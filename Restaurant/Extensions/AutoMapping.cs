using AutoMapper;
using Restaurant.Models.DTO;
using Restaurant.Models.Requests;
using Restaurant.Models.Responses;

namespace Restaurant.Host.Extensions
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<Order, OrderResponse>();
            CreateMap<OrderRequest, Order>();
        }
    }
}
