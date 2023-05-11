using Maletkunst.DAL.Interfaces;
using Maletkunst.DAL.Models;
using RestSharp;

namespace Maletkunst.DAL.RestClient;

public class OrdersDataAccess : IOrdersDataAccess
{
	private readonly string restUrl;
	public readonly RestSharp.RestClient client;

	public OrdersDataAccess()
	{
		restUrl = "https://www.maletkunst.dk/api/v1/Orders";
		//restUrl = "https://localhost:7150/v1/Paintings";

		//Robert URL nedenunder
		//restUrl = "https://localhost:7104/Paintings";

		client = new RestSharp.RestClient(restUrl);
	}
	public int CreateOrder(Order order)
	{
		var request = new RestRequest("orders", Method.Post).AddJsonBody(order);
		var response = client.Execute<int>(request);
		return response.Data;
	}

	public IEnumerable<Order> GetAllOrders()
	{
		var request = new RestRequest("orders", Method.Get);
		var response = client.Execute<List<Order>>(request);
		return response.Data;
	}
}
