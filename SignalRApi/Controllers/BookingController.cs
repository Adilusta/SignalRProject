using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.BookingDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;
        private readonly IMapper _mapper;

        public BookingController(IBookingService bookingService,IMapper mapper)
        {
            _bookingService = bookingService;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult BookingList()
        {
            var values = _mapper.Map<List<ResultBookingDto>>(_bookingService.TGetListAll());
            //var values = _bookingService.TGetListAll();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateBooking(CreateBookingDto createBookingDto)
        {
            var value = _mapper.Map<Booking>(createBookingDto);
            //Booking booking = new Booking()
            //{
            //    Mail = createBookingDto.Mail,
            //    Date = createBookingDto.Date,
            //    Name = createBookingDto.Name,
            //    PersonCount = createBookingDto.PersonCount,
            //    Phone = createBookingDto.Phone
            //};
            _bookingService.TAdd(value);
            return Ok("Rezervasyon Yapıldı");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBooking(int id)
        {
            var value = _bookingService.TGetById(id);
            _bookingService.TDelete(value);
            return Ok("Rezervasyon Silindi");
        }

        [HttpPut]
        public IActionResult UpdateBooking(UpdateBookingDto updateBookingDto)
        {
            var value = _mapper.Map<Booking>(updateBookingDto);
            //Booking booking = new Booking()
            //{
            //    Mail = updateBookingDto.Mail,
            //    BookingID = updateBookingDto.BookingID,
            //    Name = updateBookingDto.Name,
            //    PersonCount = updateBookingDto.PersonCount,
            //    Phone = updateBookingDto.Phone,
            //    Date = updateBookingDto.Date
            //};
            _bookingService.TUpdate(value);
            return Ok("Rezervasyon Güncellendi");
        }

        [HttpGet("{id}")]
        public IActionResult GetBooking(int id)
        {
            var value = _mapper.Map<ResultBookingDto>(_bookingService.TGetById(id));
            //var value = _bookingService.TGetById(id);
            return Ok(value);
        }
    }
}
