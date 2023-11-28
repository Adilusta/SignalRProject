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
    public class EfFeatureDal : EFGenericRepository<Feature>, IFeatureDal
    {
		private readonly SignalRDbContext _context;
		public EfFeatureDal(SignalRDbContext context) : base(context)
        {
            this._context = context;
        }
    }
}
