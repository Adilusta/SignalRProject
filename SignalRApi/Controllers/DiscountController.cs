using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.DiscountDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountController : ControllerBase
    {
        private readonly IDiscountService _discountService;
        private readonly IMapper _mapper;
        public DiscountController(IDiscountService discountService, IMapper mapper)
        {
            _discountService = discountService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult DiscountList()
        {
            var value = _mapper.Map<List<ResultDiscountDto>>(_discountService.TGetListAll());
            return Ok(value);
        }
        [HttpPost]
        public IActionResult CreateDiscount(CreateDiscountDto createDiscountDto)
        {
            var value = _mapper.Map<Discount>(createDiscountDto);
            _discountService.TAdd(value);
            //_discountService.TAdd(new Discount()
            //{
            //    Amount = createDiscountDto.Amount,
            //    Description = createDiscountDto.Description,
            //    ImageUrl = createDiscountDto.ImageUrl,
            //    Title = createDiscountDto.Title,
            //    Status = false
            //});
            return Ok("İndirim Bilgisi Eklendi");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteDiscount(int id)
        {
            var value = _discountService.TGetById(id);
            _discountService.TDelete(value);
            return Ok("İndirim Bilgisi Silindi");
        }
        [HttpGet("{id}")]
        public IActionResult GetDiscount(int id)
        {
            var value = _mapper.Map<ResultDiscountDto>(_discountService.TGetById(id));
            //var value = _discountService.TGetByID(id);
            return Ok(value);
        }
        [HttpPut]
        public IActionResult UpdateDiscount(UpdateDiscountDto updateDiscountDto)
        {
            var value = _mapper.Map<Discount>(updateDiscountDto);
            _discountService.TUpdate(value);
            //_discountService.TUpdate(new Discount()
            //{
            //    Amount = updateDiscountDto.Amount,
            //    Description = updateDiscountDto.Description,
            //    ImageUrl = updateDiscountDto.ImageUrl,
            //    Title = updateDiscountDto.Title,
            //    DiscountID = updateDiscountDto.DiscountID,
            //    Status = false
            //});
            return Ok("İndirim Bilgisi Güncellendi");
        }
    
    }
}
