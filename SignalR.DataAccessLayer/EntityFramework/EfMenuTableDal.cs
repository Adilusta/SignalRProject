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
	public class EfMenuTableDal : EFGenericRepository<MenuTable>, IMenuTableDal
	{
		private readonly SignalRDbContext _context;
		public EfMenuTableDal(SignalRDbContext context) : base(context)
		{
			this._context = context;
		}
		public int MenuTableCount()
		{
			return _context.MenuTables.Count();
		}
	}
}
