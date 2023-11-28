using SignalR.EntityLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.EntityLayer.Entities
{
	public class OrderDetail : IEntity
	{
        public int OrderDetailID { get; set; }
        public int ProductID { get; set; }
        public Product Product { get; set; }
        public int Count { get; set; }
        public decimal UnitPrice { get; set; }
        //totalprice=count*unitprice
        public decimal TotalPrice { get; set; }
        public int OrderID { get; set; }
        public Order Order { get; set; }

    }
}
