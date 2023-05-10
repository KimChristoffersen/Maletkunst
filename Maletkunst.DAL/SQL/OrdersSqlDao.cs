using Maletkunst.DAL.Interfaces;
using Maletkunst.DAL.Models;
using System.Data.SqlClient;
using System.Transactions;

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
        // QUERIES DEFINITIONS
        string queryStringOrder = @"insert into [Order] (Status, Total) values(@Status, @Total); SELECT CAST(scope_identity() AS int)";
        string queryStringOrderLine = @"insert into [OrderLine] values(@Quantity, @SubTotal, @OrderNumber, @Painting_Id)";
        string queryStringCorrectPaintingsStock = @"UPDATE Painting SET Stock = @stock WHERE Id = @Painting_Id AND Stock > 0";

        // STARTS USING CONNECTION
        using SqlConnection connection = new SqlConnection(connectionString);
        connection.Open();

        // STARTS TRANSACTION WITH ISOLATION LEVEL REPEATABLE READ (LOCKS TUPLE)
        SqlTransaction transaction = connection.BeginTransaction(System.Data.IsolationLevel.RepeatableRead);

        // COMMANDS
        SqlCommand commandOrder = new SqlCommand(queryStringOrder, connection, transaction);
        SqlCommand commandOrderLine = new SqlCommand(queryStringOrderLine, connection, transaction);
        SqlCommand commandCorrectPaintingsStock = new SqlCommand(queryStringCorrectPaintingsStock, connection, transaction);

        // PARAMETERS FOR ORDER CREATION
        commandOrder.Parameters.AddWithValue("@Status", order.Status);
        commandOrder.Parameters.AddWithValue("@Total", order.Total);

        try
        {
            // EXECUTION OF ORDER CREATION WITH GENERATED IDENTITY KEY
            int newGeneratedOrderNumber = (int)commandOrder.ExecuteScalar();

            // DEFINITION OF FLAG FOR ROWS AFFECTED WHEN ADJUSTING STOCK FOR PAINTING
            bool rowsAffected = true;  

            // LOOP TO CREATE ORDERLINES
            foreach (OrderLine orderLine in order.OrderLines)
            {
                // PARAMETERS FOR ORDERLINE CREATION
                commandOrderLine.Parameters.AddWithValue("@Quantity", orderLine.Quantity);
                commandOrderLine.Parameters.AddWithValue("@SubTotal", orderLine.SubTotal);
                commandOrderLine.Parameters.AddWithValue("@OrderNumber", newGeneratedOrderNumber);
                commandOrderLine.Parameters.AddWithValue("@Painting_Id", orderLine.Painting.Id);

                // EXECUTION OF ORDERLINE CREATION
                commandOrderLine.ExecuteNonQuery();

                // PARAMETERS FOR PAINTING STOCK ADJUSTMENT
                commandCorrectPaintingsStock.Parameters.AddWithValue("@Stock", 0);
                commandCorrectPaintingsStock.Parameters.AddWithValue("@Painting_Id", orderLine.Painting.Id);

                // EXECUTION OF PAINTING STOCK ADJUSTMENT AND IF STATEMENT THAT SETS FLAG FOR ROWS AFFECTED
                if (commandCorrectPaintingsStock.ExecuteNonQuery() == 0)
                {
                    rowsAffected = false; 
                }
            }

            // IF STATEMENT THAT ROLLSBACK IF ONE OF THE ORDERLINES PAINTINGS STOCK IS 0
            if (!rowsAffected)
            {
                newGeneratedOrderNumber = 0;
                try { transaction.Rollback(); }
                catch (Exception ex) { throw new Exception("ERROR occurred while rolling back", ex); }
            }
            // ELSE STATEMENT THAT SAVE THE CHANGES IN THE DATABASE
            else
            {
                transaction.Commit();      
            }

            // RETURNS THE NEW GENERATED ORDER NUMBER
            return newGeneratedOrderNumber;
        }

        // EXCEPTION HANDLING AND ROLL BACK
        catch (Exception e)
        {
            try { transaction.Rollback(); }
            catch (Exception exx) { throw new Exception("ERROR occurred while rolling back", exx); }
            throw new Exception("ERROR occurred while creating an order", e);
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
