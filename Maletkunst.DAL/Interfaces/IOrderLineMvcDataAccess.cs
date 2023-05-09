using Maletkunst.DAL.Models;

namespace Maletkunst.DAL.Interfaces;

public interface IOrderLineMvcDataAccess
{
    IEnumerable<OrderLine> GetAllOrderLines();
    IEnumerable<OrderLine> GetAllOrderLinesByOrderNumber(int orderNumber);
}
