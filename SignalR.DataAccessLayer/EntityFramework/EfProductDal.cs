using Microsoft.EntityFrameworkCore;
using SignalR.DataAccessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DataAccessLayer.Repositories;
using SignalR.DtoLayer.ProductDto;
using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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

		public int GetProductCount()
		{
            var count = _context.Products.Count();
            return count;
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

		public int GetProductCountByCategoryNameDrink()
		{
            var productCountByCategoryNameDrink = _context.Products.Where(x => x.Category.CategoryName == "İçecek").Count();
            //var productCountByCategoryNameDrink = _context.Products.Where(x => x.CategoryID == (_context.Categories.Where(y => y.CategoryName == "İçecek").Select(z => z.CategoryID).FirstOrDefault())).Count();
			return productCountByCategoryNameDrink;
		}

		public int GetProductCountByCategoryNameHamburger()
		{
			var productCountByCategoryNameDrink = _context.Products.Where(x => x.Category.CategoryName == "Hamburger").Count();
			//var productCountByCategoryNameDrink = _context.Products.Where(x => x.CategoryID == (_context.Categories.Where(y => y.CategoryName == "Hamburger").Select(z => z.CategoryID).FirstOrDefault())).Count();
			return productCountByCategoryNameDrink;
		}

		public decimal GetProductPriceAvg()
		{
			var productPriceAvg= _context.Products.Average(x => x.Price);
            return productPriceAvg;
		}

		public string GetProductNameByMaxPrice()
		{
			var productByMaxPrice = _context.Products.Where(x => x.Price == (_context.Products.Max(y => y.Price))).Select(z => z.ProductName).FirstOrDefault();
			return productByMaxPrice;
		}

		public string GetProductNameByMinPrice()
		{
			var productByMinPrice = _context.Products.Where(x => x.Price == (_context.Products.Min(y => y.Price))).Select(z => z.ProductName).FirstOrDefault();
			return productByMinPrice;
		}
	}
}
