using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DtoLayer.BasketDto;

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
    }
}
