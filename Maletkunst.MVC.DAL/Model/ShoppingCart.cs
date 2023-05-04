using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maletkunst.MVC.DAL.Model
{
	public class ShoppingCart
	{
		public List<ShoppingCartItem> Items { get; set; } = new List<ShoppingCartItem>();

		public decimal Subtotal => Items.Sum(item => item.Price * item.Quantity);

		public decimal Total => Subtotal;
	}
}
