using Maletkunst.RestApi.DAL.Model;
using System.Data.SqlClient;

namespace Maletkunst.RestApi.DAL.DataAccess;

public class PaintingDAO : IPaintingDAO
{
    private const string connectionString = @"Data Source=hildur.ucn.dk; Initial Catalog=DMA-CSD-V221_10434660; User ID=DMA-CSD-V221_10434660; Password=Password1!;";

    public IEnumerable<Painting> GetAll()
    {
        string queryString = @"SELECT * FROM Painting";
        using SqlConnection connection = new SqlConnection(connectionString);
        SqlCommand command = new SqlCommand(queryString, connection);

        connection.Open();

        try { return BuildListOfPaintings(command); }

        catch (Exception ex) { throw new Exception("ERROR occurred while getting all paintings", ex); }
    }
    public IEnumerable<Painting> GetAllAvailable()
    {
        string queryString = @"SELECT * FROM Painting WHERE stock > 0";
        using SqlConnection connection = new SqlConnection(connectionString);
        SqlCommand command = new SqlCommand(queryString, connection);

        connection.Open();

        try { return BuildListOfPaintings(command); }

        catch (Exception ex) { throw new Exception("ERROR occurred while getting all paintings", ex); }
    }


    public IEnumerable<Painting> GetAllFreeSearch(string searchString)
    {
        string queryString = @"SELECT * FROM Painting WHERE Stock > 0 AND (Title LIKE '%' + @searchString + '%' OR Artist LIKE '%' + @searchString + '%' OR [Description] LIKE '%' + @searchString + '%')";
        using SqlConnection connection = new SqlConnection(connectionString);
        SqlCommand command = new SqlCommand(queryString, connection);

        command.Parameters.AddWithValue("@searchString", searchString);

        connection.Open();

        try { return BuildListOfPaintings(command); }

        catch (Exception ex) { throw new Exception("ERROR occurred while getting all paintings", ex); }
    }

    public IEnumerable<Painting> GetAllByCategory(string category)
    {
        string queryString = @"SELECT * FROM Painting WHERE stock > 0 and category like '%' + @category + '%'";
        using SqlConnection connection = new SqlConnection(connectionString);
        SqlCommand command = new SqlCommand(queryString, connection);
        command.Parameters.AddWithValue("@category", category);

        connection.Open();
        try
        {
            return BuildListOfPaintings(command);

        }
        catch (Exception ex)
        {
            throw new Exception("ERROR occurred while getting all paintings", ex);
        }
    }

    public IEnumerable<Painting> GetAllByCategoryAndFreeSearch(string category, string searchString)
    {
        string queryString = @"SELECT * FROM Painting WHERE Stock > 0 AND Category like '%' + @category + '%' AND (Title LIKE '%' + @searchString + '%' OR Artist LIKE '%' + @searchString + '%' OR [Description] LIKE '%' + @searchString + '%')";
        using SqlConnection connection = new SqlConnection(connectionString);
        SqlCommand command = new SqlCommand(queryString, connection);

        command.Parameters.AddWithValue("@category", category);
        command.Parameters.AddWithValue("@searchString", searchString);

        connection.Open();

        try { return BuildListOfPaintings(command); }

        catch (Exception ex) { throw new Exception("ERROR occurred while getting all paintings", ex); }
    }

    private IEnumerable<Painting> BuildListOfPaintings(SqlCommand command)
    {
        SqlDataReader reader = command.ExecuteReader();
        List<Painting> paintings = new List<Painting>();
        while (reader.Read())
        {
            paintings.Add(new Painting()
            {
                Id = (int)reader["ID"],
                Title = (string)reader["Title"],
                Price = (decimal)reader["Price"],
                Stock = (int)reader["Stock"],
                Artist = (string)reader["Artist"],
                Description = (string)reader["Description"],
                Category = (string)reader["Category"]
            });
        }
        return paintings;
    }

    public int CreatePainting(Painting painting)
    {
        string queryString = @"INSERT INTO Painting values(@Title,@Price,@Stock,@Artist,@Description,@Category); SELECT CAST(scope_identity() AS int)";
        using SqlConnection connection = new SqlConnection(connectionString);
        connection.Open();
        SqlTransaction transaction = connection.BeginTransaction();
        SqlCommand command = new SqlCommand(queryString, connection, transaction);

        command.Parameters.AddWithValue("@Title", painting.Title);
        command.Parameters.AddWithValue("@Price", painting.Price);
        command.Parameters.AddWithValue("@Stock", painting.Stock);
        command.Parameters.AddWithValue("@Artist", painting.Artist);
        command.Parameters.AddWithValue("@Description", painting.Description);
        command.Parameters.AddWithValue("@Category", painting.Category);

        int NewGeneratedPaintingId = 0;
        try
        {
            NewGeneratedPaintingId = (int)command.ExecuteScalar();
            transaction.Commit();
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
                throw new Exception("ERROR occurred while creating a painting", ex);
            }
        }
        return NewGeneratedPaintingId;
    }

    public bool DeletePainting(int id)
    {
        string queryString = @"DELETE FROM Painting WHERE id = @id";
        using SqlConnection connection = new SqlConnection(connectionString);
        SqlCommand command = new SqlCommand(queryString, connection);
        command.Parameters.AddWithValue("@id", id);
        connection.Open();

        try
        {
            command.ExecuteNonQuery();
            return true;
        }
        catch (Exception ex)
        {
            throw new Exception("ERROR occurred while deleting painting", ex);
        }
    }
}
