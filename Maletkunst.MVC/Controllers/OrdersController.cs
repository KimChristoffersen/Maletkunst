using Maletkunst.DAL.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Maletkunst.MVC.Controllers
{
	public class OrdersController : Controller
	{



		public IActionResult Index(string shoppingCart)
		{
			ShoppingCart cart = JsonConvert.DeserializeObject<ShoppingCart>(shoppingCart);

			Order order = new Order();
			order.OrderDate = DateTime.Now;
			List<OrderLine> orderlines = new List<OrderLine>();

			foreach (var item in cart.Items)
			{
				Painting painting = new Painting();
				OrderLine orderline = new();
				painting.Title = item.Name;
				painting.Price = item.Price;
				painting.Id = item.Id;
				painting.Stock = item.Quantity;
				orderline.Painting = painting;
				order.Total = cart.Total;

				orderlines.Add(orderline);

				//order.OrderLines.ToList().Add(orderline);


			}
			order.OrderLines = orderlines;

			return View(order);
		}



		// GET: OrdersController/Create
		public ActionResult Create()
		{

			return View();
		}

		// POST: OrdersController/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(Order order)
		{
			try
			{

				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}
	}
}



