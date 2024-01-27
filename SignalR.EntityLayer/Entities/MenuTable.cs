using SignalR.EntityLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.EntityLayer.Entities
{
	public class MenuTable : IEntity
	{
		public int MenuTableID { get; set; }
		public string Name { get; set; }
		public bool Status { get; set; }
		public List<Order> Orders { get; set; }
	}
}
