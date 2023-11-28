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
    public class EfCategoryDal : EFGenericRepository<Category> , ICategoryDal
    {
		private readonly SignalRDbContext _context;
		public EfCategoryDal(SignalRDbContext context) : base(context)
        {
			this._context = context;
        }
		public int GetCategoryCount()
		{
			var count = _context.Categories.Count();
			return count;
		}

		public int GetPassiveCategoryCount()
		{
			var passiveCategoryCount = _context.Categories.Where(x => x.CategoryStatus == false).Count();
			return passiveCategoryCount;
		}

		public int GetActiveCategoryCount()
		{
			var activeCategoryCount =_context.Categories.Where(x=> x.CategoryStatus==true).Count();
			return activeCategoryCount;
		}
	}
}
