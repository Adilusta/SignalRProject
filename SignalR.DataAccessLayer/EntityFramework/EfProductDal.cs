using Microsoft.EntityFrameworkCore;
using SignalR.DataAccessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DataAccessLayer.Repositories;
using SignalR.DtoLayer.ProductDto;
using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DataAccessLayer.EntityFramework
{
    public class EfProductDal : EFGenericRepository<Product>, IProductDal
    {
        SignalRDbContext _context;
        
        public EfProductDal(SignalRDbContext context) : base(context)
        {
            this._context = context;
        }

        public List<Product> GetProductsWithCategories()
        {
            var values = _context.Products.Include(x => x.Category).ToList();
            return values;
            //var values = _context.Products.Include(x => x.Category).Select(y => new ResultProductWithCategoryDto
            //{
            //    Description= y.Description,
            //    ImageUrl = y.ImageUrl,
            //    Price=y.Price,
            //    ProductID=y.ProductID,
            //    ProductName=y.ProductName,
            //    ProductStatus = y.ProductStatus,
            //    CategoryName = y.Category.CategoryName
            //}).ToList();

        }
    }
}
