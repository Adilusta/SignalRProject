using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Abstract;
using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.BusinessLayer.Concrete
{
    public class ProductManager : IProductService
    {
        private readonly IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

		public int GetProductCount()
		{
            var count = _productDal.GetProductCount();
            return count;
		}

		public List<Product> GetProductsWithCategories()
        {
           return _productDal.GetProductsWithCategories();
        }

        public void TAdd(Product entity)
        {
            _productDal.Add(entity);
        }

        public void TDelete(Product entity)
        {
            _productDal.Delete(entity);
        }

        public Product TGetById(int id)
        {
            return _productDal.GetById(id);
        }

        public List<Product> TGetListAll()
        {
           return _productDal.GetListAll();
        }

		public int TGetProductCountByCategoryNameDrink()
		{
            var productCountByCategoryNameDrink = _productDal.GetProductCountByCategoryNameDrink();

            return productCountByCategoryNameDrink;
		}

		public int TGetProductCountByCategoryNameHamburger()
		{
            var productCountByCategoryNameHamburger = _productDal.GetProductCountByCategoryNameHamburger();
            return productCountByCategoryNameHamburger;
		}

		public string TGetProductNameByMaxPrice()
		{
            var productNameByMaxPrice = _productDal.GetProductNameByMaxPrice();
            return productNameByMaxPrice;
		}

		public string TGetProductNameByMinPrice()
		{
			var productNameByMinPrice = _productDal.GetProductNameByMinPrice();
			return productNameByMinPrice;
		}

		public decimal TGetProductPriceAvg()
		{
			var productPriceAvg = _productDal.GetProductPriceAvg();
            return productPriceAvg;
		}

		public void TUpdate(Product entity)
        {
            _productDal.Update(entity);
        }
    }
}
