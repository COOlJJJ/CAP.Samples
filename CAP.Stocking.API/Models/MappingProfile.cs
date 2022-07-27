using AutoMapper;

namespace CAP.Stocking.API.Models
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<StockDTO, Stock>().ReverseMap();
            CreateMap<Stock, StockVO>();
        }
    }
}
