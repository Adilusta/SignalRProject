using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DtoLayer.BasketDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IBasketService _basketService;
        private readonly IMapper _mapper;
        public BasketController(IBasketService basketService,IMapper mapper)
        {
            _basketService = basketService;
            _mapper=mapper;
        }

        [HttpGet]
        public IActionResult GetBasketByMenuTableID(int menuTableID)
        {
            var basket= _basketService.TGetBasketByMenuTableNumber(menuTableID);
            var values = _mapper.Map<List<ResultBasketDto>>(basket);
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateBasket(CreateBasketDto createBasketDto)
        {
            using var context = new SignalRDbContext();
            _basketService.TAdd(new Basket()
            {
                ProductID = createBasketDto.ProductID,
                Count = 1,
                MenuTableID = 1,
                Price = context.Products.Where(x => x.ProductID == createBasketDto.ProductID).Select(y => y.Price).FirstOrDefault(),
                TotalPrice = 0
            });
            return Ok();
        }
    }
}
