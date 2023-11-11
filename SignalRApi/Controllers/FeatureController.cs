using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.FeatureDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeatureController : ControllerBase
    {
        private readonly IFeatureService _featureService;
        private readonly IMapper _mapper;

        public FeatureController(IFeatureService featureService, IMapper mapper)
        {
            _featureService = featureService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult FeatureList()
        {
            var value = _mapper.Map<List<ResultFeatureDto>>(_featureService.TGetListAll());
            return Ok(value);
        }
        [HttpPost]
        public IActionResult CreateFeature(CreateFeatureDto createFeatureDto)
        {
            var value = _mapper.Map<Feature>(createFeatureDto);
            _featureService.TAdd(value);
            //_discountService.TAdd(new Discount()
            //{
            //    Amount = createDiscountDto.Amount,
            //    Description = createDiscountDto.Description,
            //    ImageUrl = createDiscountDto.ImageUrl,
            //    Title = createDiscountDto.Title,
            //    Status = false
            //});
            return Ok("Öne çıkan Bilgisi Eklendi");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteFeature(int id)
        {
            var value = _featureService.TGetById(id);
            _featureService.TDelete(value);
            return Ok("Öne çıkan Bilgisi Silindi");
        }
        [HttpGet("{id}")]
        public IActionResult GetFeature(int id)
        {
            var value = _mapper.Map<ResultFeatureDto>(_featureService.TGetById(id));
            //var value = _discountService.TGetByID(id);
            return Ok(value);
        }
        [HttpPut]
        public IActionResult UpdateFeature(UpdateFeatureDto updateFeatureDto)
        {
            var value = _mapper.Map<Feature>(updateFeatureDto);
            _featureService.TUpdate(value);
            //_discountService.TUpdate(new Discount()
            //{
            //    Amount = updateDiscountDto.Amount,
            //    Description = updateDiscountDto.Description,
            //    ImageUrl = updateDiscountDto.ImageUrl,
            //    Title = updateDiscountDto.Title,
            //    DiscountID = updateDiscountDto.DiscountID,
            //    Status = false
            //});
            return Ok("Öne çıkan Bilgisi Güncellendi");
        }
    }
}
