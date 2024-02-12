using AutoMapper;
using SignalR.DtoLayer.BasketDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Mapping
{
    public class BasketMapping : Profile
    {
        public BasketMapping()
        {
            CreateMap<Basket, CreateBasketDto>().ReverseMap();
            CreateMap<Basket, ResultBasketDto>().ReverseMap();
        }
    }
}
