using Maletkunst.DAL.Models;

namespace Maletkunst.DAL.Interfaces;

public interface ICustomersDao
{
	IEnumerable<Customer> GetAllCustomers();
	int CreateCustomer(Customer customer);
	bool DeleteCustomer(int id);
	bool UpdateCustomer(Customer customer);
}
