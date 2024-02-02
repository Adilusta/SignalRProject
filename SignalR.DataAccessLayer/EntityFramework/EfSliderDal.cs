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
    public class EfSliderDal : EFGenericRepository<Slider>, ISliderDal
    {
        SignalRDbContext _context;

        public EfSliderDal(SignalRDbContext context) : base(context)
        {
           this._context = context;
        }
    }
}