using Maletkunst.DAL.Interfaces;
using Maletkunst.DAL.Models;
using Maletkunst.DAL.RestClient;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Maletkunst.MVC.Controllers;

public class OrdersController : Controller
{
	IOrdersDataAccess _client;

	public OrdersController(IOrdersDataAccess client)
	{
		_client = client;
	}


	public IActionResult Index(string shoppingCart)
	{
		Order order = CreateOrderWithShoppingCart(shoppingCart);

		return View(order);
	}

	private Order CreateOrderWithShoppingCart(string shoppingCart)
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
		
		int orderNumber = _client.CreateOrder(order);
		

		return order;
	}



	// GET: OrdersController/Create
	public ActionResult Create(string shoppingCart)
	{
		Order order = CreateOrderWithShoppingCart(shoppingCart);

		return View(order);
	}

	// POST: OrdersController/Create
	[HttpPost]
	[ValidateAntiForgeryToken]
	public ActionResult Create(Order order)
	{
		try
		{
			int orderId = _client.CreateOrder(order);
			return RedirectToAction(nameof(Index));
		}
		catch
		{
			return View();
		}
	}
}



