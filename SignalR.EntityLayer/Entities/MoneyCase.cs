﻿using SignalR.EntityLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.EntityLayer.Entities
{
	public class MoneyCase : IEntity
	{
		public int MoneyCaseID { get; set; }
		public decimal TotalAmount { get; set; }
	}
}
