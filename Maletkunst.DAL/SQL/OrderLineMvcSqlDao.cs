using Maletkunst.DAL.Interfaces;
using Maletkunst.DAL.Models;
using System.Data.SqlClient;

namespace Maletkunst.DAL.SQL;

public class OrderLineMvcSqlDao : IOrderLineMvcDataAccess
{
    private const string connectionString = @"Data Source=hildur.ucn.dk; Initial Catalog=DMA-CSD-V221_10434660; User ID=DMA-CSD-V221_10434660; Password=Password1!;";

    private IPaintingsDataAccess _paintingMvcDataAccess = new PaintingsSqlDataAccess();


    public IEnumerable<OrderLine> GetAllOrderLines()
    {
        string queryString = @"SELECT * FROM OrderLine";
        using SqlConnection connection = new SqlConnection(connectionString);
        SqlCommand command = new SqlCommand(queryString, connection);

        connection.Open();

        try { return BuildListOfOrderLines(command); }

        catch (Exception ex) { throw new Exception("ERROR occurred while getting all order lines", ex); }
    }

    public IEnumerable<OrderLine> GetAllOrderLinesByOrderNumber(int orderNumber)
    {
        string queryString = @"SELECT * FROM OrderLine WHERE Order_Id = @OrderNumber";
        using SqlConnection connection = new SqlConnection(connectionString);
        SqlCommand command = new SqlCommand(queryString, connection);
        command.Parameters.AddWithValue("@OrderNumber", orderNumber);

        connection.Open();

        try { return BuildListOfOrderLines(command); }

        catch (Exception ex) { throw new Exception("ERROR occurred while getting all order lines", ex); }
    }


    private IEnumerable<OrderLine> BuildListOfOrderLines(SqlCommand command)
    {
        SqlDataReader reader = command.ExecuteReader();
        ICollection<OrderLine> orderLines = new List<OrderLine>();
        while (reader.Read())
        {
            orderLines.Add(new OrderLine()
            {
                OrderLineId = (int)reader["OrderLineId"],
                Quantity = (int)reader["Quantity"],
                SubTotal = (decimal)reader["SubTotal"],
                Painting = _paintingMvcDataAccess.GetPaintingById((int)reader["Painting_Id"])
            });
        }
        return orderLines;
    }


}