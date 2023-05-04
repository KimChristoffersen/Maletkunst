using Maletkunst.RestApi.DAL.Model;

namespace Maletkunst.RestApi.DAL.Interface;

public interface IOrderMvcDataAccess
{
    IEnumerable<Order> GetAllOrders();
    int CreateOrder(Order order);
}
