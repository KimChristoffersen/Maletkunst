using Maletkunst.DAL.Interfaces;
using Maletkunst.DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maletkunst.DAL.SQL;

public class CustomersSqlDao : ICustomersDao
{
	private string connectionString = @"Data Source=hildur.ucn.dk; Initial Catalog=DMA-CSD-V221_10434660; User ID=DMA-CSD-V221_10434660; Password=Password1!;";

	public IEnumerable<Customer> GetAllCustomers()
	{
		string queryString = @"SELECT c.Customer_Id, p.fName AS FirstName, p.lName AS LastName, a.address AS Address, a.postalCode AS PostalCode,
                           pc.city AS City, p.phone AS Phone, p.email AS Email, c.Discount
                           FROM Customer c
                           INNER JOIN Person p ON c.Customer_Id = p.PersonId
                           INNER JOIN Address a ON p.PersonId = a.personId
                           INNER JOIN PostalCode pc ON a.postalCode = pc.postalcode";
		;
		using SqlConnection connection = new SqlConnection(connectionString);
		SqlCommand command = new SqlCommand(queryString, connection);

		connection.Open();
		
		try { return BuildListOfCustomers(command); }

		catch (Exception ex) { throw new Exception("ERROR occurred while getting all customers", ex); }
	}

	public int CreateCustomer(Customer customer)
	{
		// QUERIES DEFINITIONS
		string queryStringPerson = @"INSERT INTO Person (fName, lName, phone, email, personType) 
                                   VALUES (@fName, @lName, @phone, @email, @personType);
                                   SELECT CAST(scope_identity() AS int)";

		string queryStringCustomer = @"INSERT INTO Customer (Customer_Id, Discount) 
                                     VALUES (@customerId, @discount)";

		string queryStringAddress = @"INSERT INTO Address (address, personId, postalCode) 
                                    VALUES (@address, @personId, @postalCode)";



		// STARTS USING CONNECTION
		using SqlConnection connection = new SqlConnection(connectionString);
		connection.Open();

		// STARTS TRANSACTION WITH ISOLATION LEVEL REPEATABLE READ (LOCKS TUPLE)
		SqlTransaction transaction = connection.BeginTransaction(System.Data.IsolationLevel.RepeatableRead);

		// COMMANDS
		SqlCommand commandPerson = new SqlCommand(queryStringPerson, connection, transaction);
		SqlCommand commandCustomer = new SqlCommand(queryStringCustomer, connection, transaction);
		SqlCommand commandAddress = new SqlCommand(queryStringAddress, connection, transaction);

		// PARAMETERS FOR PERSON CREATION
		commandPerson.Parameters.AddWithValue("@fName", customer.FirstName);
		commandPerson.Parameters.AddWithValue("@lName", customer.LastName);
		commandPerson.Parameters.AddWithValue("@phone", customer.Phone);
		commandPerson.Parameters.AddWithValue("@email", customer.Email);
		commandPerson.Parameters.AddWithValue("@personType", "Customer");

		try
		{
			// EXECUTION OF PERSON CREATION WITH GENERATED IDENTITY KEY
			int NewGeneratedPersonId = (int)commandPerson.ExecuteScalar();

			// PARAMETERS FOR CUSTOMER CREATION
			commandCustomer.Parameters.AddWithValue("@customerId", NewGeneratedPersonId);
			commandCustomer.Parameters.AddWithValue("@discount", 0);

			// EXECUTION OF CUSTOMER CREATION
			commandCustomer.ExecuteNonQuery();

			// PARAMETERS FOR ADDRESS CREATION
			commandAddress.Parameters.AddWithValue("@address", customer.Address);
			commandAddress.Parameters.AddWithValue("@personId", NewGeneratedPersonId);
			commandAddress.Parameters.AddWithValue("@postalCode", customer.PostalCode);

			// EXECUTION OF ADDRESS CREATION
			commandAddress.ExecuteNonQuery();

			// SAVES THE CHANGES IN THE DATABASE
			transaction.Commit();

			// RETURNS THE NEW GENERATED PERSON NUMBER
			return NewGeneratedPersonId;
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
				throw new Exception("ERROR occurred while creating a customer", ex);
			}
		}
	}

	public bool DeleteCustomer(int id)
	{
		throw new NotImplementedException();
	}


	public bool UpdateCustomer(Customer customer)
	{
		throw new NotImplementedException();
	}

	private IEnumerable<Customer> BuildListOfCustomers(SqlCommand command)
	{
		SqlDataReader reader = command.ExecuteReader();
		List<Customer> customers = new List<Customer>();
		while (reader.Read())
		{
			customers.Add(new Customer()
			{
				Id = (int)reader["Customer_Id"],
				FirstName = (string)reader["FirstName"],
				LastName = (string)reader["LastName"],
				Address = (string)reader["Address"],
				PostalCode = (int)reader["PostalCode"],
				City = (string)reader["City"],
				Phone = (string)reader["Phone"],
				Email = (string)reader["Email"],
				Discount = (int)reader["Discount"]
			});
		}
		return customers;
	}
}