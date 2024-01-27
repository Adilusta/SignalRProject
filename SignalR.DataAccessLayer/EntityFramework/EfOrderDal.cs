using SignalR.DataAccessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DataAccessLayer.Repositories;
using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DataAccessLayer.EntityFramework
{
	public class EfOrderDal : EFGenericRepository<Order>, IOrderDal
	{
		private readonly SignalRDbContext _context;
		public EfOrderDal(SignalRDbContext context) : base(context)
		{
			this._context = context;
		}

		public int ActiveOrderCount()
		{
			var activeOrderCount = _context.Orders.Where(x => x.Description == "Müşteri Masada").Count();
			return activeOrderCount;
		}

		public decimal LastOrderPrice()
		{
			var lastOrderPrice = _context.Orders.OrderByDescending(x => x.OrderID).Take(1).Select(y => y.TotalPrice).FirstOrDefault();
			return lastOrderPrice;
		}

		public decimal TodayTotalPrice()
		{
			var todayTotalPrice= _context.Orders.Where(x=>x.Date.Date==DateTime.Today).Where(y=>y.Description=="Hesap Ödendi").Sum(x => x.TotalPrice);
			return todayTotalPrice;
		}

		public int TotalOrderCount()
		{
			var totalOrderCount= _context.Orders.Count();
			return totalOrderCount;
		}
	}
}
