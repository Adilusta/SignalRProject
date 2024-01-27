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
	public class EfMoneyCaseDal : EFGenericRepository<MoneyCase>, IMoneyCaseDal
	{
		private readonly SignalRDbContext _context;

		public EfMoneyCaseDal(SignalRDbContext context) : base(context)
		{
			_context = context;
		}

		public decimal GetTotalMoneyCaseAmount()
		{
			var totalMoneyCaseAmount =Convert.ToDecimal ( _context.MoneyCases.Select(x => x.TotalAmount).FirstOrDefault());
			return totalMoneyCaseAmount;
		}
	}
}
