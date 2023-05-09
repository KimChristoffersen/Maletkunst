using Maletkunst.DAL.Models;

namespace Maletkunst.DAL.Interfaces;

public interface IOrderMvcDataAccess
{
    IEnumerable<Order> GetAllOrders();
    int CreateOrder(Order order);
}
