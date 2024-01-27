using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;

namespace SignalRApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class OrderController : ControllerBase
	{
		private readonly IOrderService _orderService;
		private readonly IMapper _mapper;

		public OrderController(IOrderService orderService, IMapper mapper)
		{
			_orderService = orderService;
			_mapper = mapper;
		}
		[HttpGet("TotalOrderCount")]
		public IActionResult TotalOrderCount()
		{
			var totalOrderCount = _orderService.TotalOrderCount();
			return Ok(totalOrderCount);
		}
		[HttpGet("ActiveOrderCount")]
		public IActionResult ActiveOrderCount()
		{
			var activeOrderCount = _orderService.GetActiveOrderCount();
			return Ok(activeOrderCount);
		}
	}
}
