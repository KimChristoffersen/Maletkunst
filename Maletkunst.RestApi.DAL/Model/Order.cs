namespace Maletkunst.RestApi.DAL.Model;

public class Order
{
    public int OrderNumber { get; set; }
    public DateTime OrderDate { get; set; }
    public string Status { get; set; }
    public decimal Total { get; set; }
    public IEnumerable<OrderLine> OrderLines { get; set; } = new List<OrderLine>();
}
