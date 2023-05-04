using Maletkunst.RestApi.DAL.Model;

namespace Maletkunst.RestApi.DAL.Interface;

public interface IOrderLineMvcDataAccess
{
    IEnumerable<OrderLine> GetAllOrderLines();
    IEnumerable<OrderLine> GetAllOrderLinesByOrderNumber(int orderNumber);
}
