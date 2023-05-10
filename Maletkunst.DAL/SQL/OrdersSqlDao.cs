using Maletkunst.DAL.Interfaces;
using Maletkunst.DAL.Models;
using System.Data.SqlClient;

namespace Maletkunst.DAL.SQL;

public class OrdersSqlDao : IOrdersDataAccess
{
    private const string connectionString = @"Data Source=hildur.ucn.dk; Initial Catalog=DMA-CSD-V221_10434660; User ID=DMA-CSD-V221_10434660; Password=Password1!;";

    private IPaintingsDataAccess _paintingSqlDataAccess = new PaintingsSqlDataAccess();

    public IEnumerable<Order> GetAllOrders()
    {
        string queryString = @"SELECT * FROM [Order]";
        using SqlConnection connection = new SqlConnection(connectionString);
        SqlCommand command = new SqlCommand(queryString, connection);

        connection.Open();

        try { return BuildListOfOrders(command); }

        catch (Exception ex) { throw new Exception("ERROR occurred while getting all orders", ex); }
    }

    private IEnumerable<Order> BuildListOfOrders(SqlCommand command)
    {
        SqlDataReader reader = command.ExecuteReader();
        ICollection<Order> orders = new List<Order>();
        while (reader.Read())
        {
            orders.Add(new Order()
            {
                OrderNumber = (int)reader["OrderNumber"],
                OrderDate = (DateTime)reader["OrderDate"],
                Status = (string)reader["Status"],
                Total = (decimal)reader["Total"],
                OrderLines = GetAllOrderLinesByOrderNumber((int)reader["OrderNumber"])
            });
        }
        return orders;
    }

    public int CreateOrder(Order order)
    {
        string queryStringOrder = @"insert into [Order] (Status, Total) values(@Status, @Total); SELECT CAST(scope_identity() AS int)";
        string queryStringOrderLine = @"insert into [OrderLine] values(@Quantity, @SubTotal, @OrderNumber, @Painting_Id)";
        string queryStringCorrectPaintingsStock = @"UPDATE Painting SET Stock = @stock WHERE Id = @Painting_Id AND Stock > 0";

        using SqlConnection connection = new SqlConnection(connectionString);
        connection.Open();

        SqlTransaction transaction = connection.BeginTransaction();
        SqlCommand commandOrder = new SqlCommand(queryStringOrder, connection, transaction);
        SqlCommand commandOrderLine = new SqlCommand(queryStringOrderLine, connection, transaction);
        SqlCommand commandCorrectPaintingsStock = new SqlCommand(queryStringCorrectPaintingsStock, connection, transaction);

        commandOrder.Parameters.AddWithValue("@Status", order.Status);
        commandOrder.Parameters.AddWithValue("@Total", order.Total);

        try
        {
            // Order generation
            int newGeneratedOrderNumber = (int)commandOrder.ExecuteScalar();

            // OrderLine generation
            bool rowsAreAffected = true;
            while (rowsAreAffected)
            {
                foreach (OrderLine orderLine in order.OrderLines)
                {
                    commandOrderLine.Parameters.AddWithValue("@Quantity", orderLine.Quantity);
                    commandOrderLine.Parameters.AddWithValue("@SubTotal", orderLine.SubTotal);
                    commandOrderLine.Parameters.AddWithValue("@OrderNumber", newGeneratedOrderNumber);
                    commandOrderLine.Parameters.AddWithValue("@Painting_Id", orderLine.Painting.Id);
                    commandOrderLine.ExecuteNonQuery();

                    // PaintingsStock correction
                    commandCorrectPaintingsStock.Parameters.AddWithValue("@Stock", 0);
                    commandCorrectPaintingsStock.Parameters.AddWithValue("@Painting_Id", orderLine.Painting.Id);
                    if (commandCorrectPaintingsStock.ExecuteNonQuery() == 0) { rowsAreAffected = false; }
                }
            }




            transaction.Commit();
            return newGeneratedOrderNumber;


        }

        catch (Exception e)
        {
            try
            {
                transaction.Rollback();
                throw new Exception("ERROR occurred while rolling back", e);
            }
            catch (Exception ex)
            {
                throw new Exception("ERROR occurred while creating a order", ex);
            }
        }
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
                Painting = _paintingSqlDataAccess.GetPaintingById((int)reader["Painting_Id"])
            });
        }
        return orderLines;
    }

}
