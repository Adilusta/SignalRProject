using Microsoft.EntityFrameworkCore;
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
    public class EfBasketDal : EFGenericRepository<Basket>, IBasketDal
    {
        private readonly SignalRDbContext _context;
        public EfBasketDal(SignalRDbContext context) : base(context)
        {
            this._context = context;
        }
        public List<Basket> GetBasketByMenuTableNumber(int id)
        {
            var values = _context.Baskets.Where(x => x.MenuTableID == id).Include(x=>x.Product).ToList();
            return values;
        }
    }
}
