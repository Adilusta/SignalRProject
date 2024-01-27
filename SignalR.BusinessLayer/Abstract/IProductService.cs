using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.BusinessLayer.Abstract
{
    public interface IProductService : IGenericService<Product>
    {
        List<Product> GetProductsWithCategories();
		int GetProductCount();
		int TGetProductCountByCategoryNameDrink();
		int TGetProductCountByCategoryNameHamburger();
		decimal TGetProductPriceAvg();
		string TGetProductNameByMaxPrice();
		string TGetProductNameByMinPrice();
		decimal ProductPriceAvgByHamburger();
	}
}
