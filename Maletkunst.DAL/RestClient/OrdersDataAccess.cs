using Maletkunst.DAL.Interfaces;
using Maletkunst.DAL.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maletkunst.DAL.RestClient;

public class OrdersDataAccess : IOrdersDataAccess
{

    RestSharp.RestClient restClient = new RestSharp.RestClient("https://www.maletkunst.dk/api/v1");
    //RestClient restClient = new RestClient("https://localhost:7150/v1");
    public int CreateOrder(Order order)
    {
        var request = new RestRequest("orders", Method.Post).AddJsonBody(order);
        var response = restClient.Execute<int>(request);
        return response.Data;
    }


    public IEnumerable<Order> GetAllOrders()
    {
        var request = new RestRequest("orders", Method.Get);
        var response = restClient.Execute<List<Order>>(request);
        return response.Data;
    }
}
