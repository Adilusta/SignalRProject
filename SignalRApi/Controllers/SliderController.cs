using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.SliderDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SliderController : ControllerBase
    {
        private readonly ISliderService _sliderService;
        private readonly IMapper _mapper;

        public SliderController(ISliderService sliderService, IMapper mapper)
        {
            _sliderService = sliderService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult SliderList()
        {
            var sliders = _sliderService.TGetListAll();
            var value = _mapper.Map<List<ResultSliderDto>>(sliders);
            return Ok(value);
        }
        [HttpPost]
        public IActionResult CreateSlider(CreateSliderDto createSliderDto)
        {
           var value= _mapper.Map<Slider>(createSliderDto);
            _sliderService.TAdd(value);
            return Ok("Öne Çıkan Bilgisi Eklendi");
          
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteSlider(int id)
        {
            var value = _sliderService.TGetById(id);
            _sliderService.TDelete(value);
            return Ok("Öne Çıkan Bilgisi Silindi");
        }
        [HttpGet("{id}")]
        public IActionResult GetSlider(int id)
        {
            var slider = _sliderService.TGetById(id);
            var value = _mapper.Map<ResultSliderDto>(slider);
            return Ok(value);
        }
        [HttpPut]
        public IActionResult UpdateSlider(UpdateSliderDto updateSliderDto)
        {
            var value = _mapper.Map<Slider>(updateSliderDto);
            _sliderService.TUpdate(value);
            //_sliderService.TUpdate(new Slider()
            //{
            //    Description1 = updateSliderDto.Description1,
            //    Description2 = updateSliderDto.Description2,
            //    Description3 = updateSliderDto.Description3,
            //    Title1 = updateSliderDto.Title1,
            //    Title2 = updateSliderDto.Title2,
            //    Title3 = updateSliderDto.Title3,
            //    SliderID = updateSliderDto.SliderID
            //});
            return Ok("Öne Çıkan Alan Bilgisi Güncellendi");
        }
    }
}
