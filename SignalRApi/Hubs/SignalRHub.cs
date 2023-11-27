using Microsoft.AspNetCore.SignalR;
using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;

namespace SignalRApi.Hubs
{
	public class SignalRHub : Hub
	{
		private readonly SignalRDbContext _context;

		public SignalRHub(SignalRDbContext context)
		{
			_context = context;
		}

		public async Task SendCategoryCount()
		{
			var value = _context.Categories.Count();
			await Clients.All.SendAsync("ReceiveCategoryCount",value);
		}
	}
}
