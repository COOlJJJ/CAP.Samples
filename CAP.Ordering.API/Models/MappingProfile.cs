using AutoMapper;

namespace CAP.Ordering.API.Models
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<OrderDTO, Order>().ReverseMap();
            CreateMap<Order, OrderVO>();
        }
    }
}
