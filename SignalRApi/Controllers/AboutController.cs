using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.AboutDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutController : ControllerBase
    {
        private readonly IAboutService _aboutService;
        private readonly IMapper _mapper;
        public AboutController(IAboutService aboutService, IMapper mapper)
        {
            _aboutService = aboutService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult AboutList()
        {
            var values = _mapper.Map<ResultAboutDto>(_aboutService.TGetListAll());
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateAbout(CreateAboutDto createAboutDto)
        {
            var value=_mapper.Map<About>(createAboutDto);
            //About about = new About()
            //{
            //    Title= createAboutDto.Title,
            //    Description= createAboutDto.Description,
            //    ImageURL= createAboutDto.ImageURL
            //};
            _aboutService.TAdd(value);
            return Ok("Hakkımda kısmı başarılı bir şekilde eklendi.");
        }
        [HttpDelete]
        public IActionResult DeleteAbout(int id)
        {
            var value = _aboutService.TGetById(id);
            _aboutService.TDelete(value);
            return Ok("Hakkımda alanı silindi");
        }
        [HttpPut]
        public IActionResult UpdateAboutAbout(UpdateAboutDto updateAboutDto)
        {
            var value=_mapper.Map<About>(updateAboutDto);
            //About about = new About()
            //{
            //    AboutID = updateAboutDto.AboutID,
            //    Title = updateAboutDto.Title,
            //    Description = updateAboutDto.Description,
            //    ImageURL = updateAboutDto.ImageURL
            //};
            _aboutService.TUpdate(value);
            return Ok("Hakkımda alanı güncellendi");
        }

        [HttpGet("GetAbout")]
        public IActionResult GetAbout(int id)
        {
            var value = _mapper.Map<ResultAboutDto>(_aboutService.TGetById(id));
            //var value = _aboutService.TGetById(id);
            return Ok(value);
        }
    }
}
