using Maletkunst.DAL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Maletkunst.DAL.Models;

namespace Maletkunst.RestApi.Controllers
{
	[Route("v1/[controller]")]
	[ApiController]
	public class CustomersController : ControllerBase
	{
		private ICustomersDao _customersDao;
		public CustomersController(ICustomersDao customersDao) => _customersDao = customersDao;


		[HttpGet]
		public ActionResult<IEnumerable<Customer>> GetAllCustomers()
		{
			var customers = _customersDao.GetAllCustomers();

			if (customers == null) { return NotFound(); }

			if (!customers.Any()) { return NoContent(); }

			return Ok(customers);
		}

		[HttpGet("{id}")]
		public string Get(int id)
		{
			return "value";
		}

		[HttpPost]
		public ActionResult<int> CreateCustomer(Customer customer)
		{
			int id = _customersDao.CreateCustomer(customer);

			if (id == 0) { return BadRequest(); }

			return Ok(id);
		}

		[HttpPut("{id}")]
		public void Put(int id, [FromBody] string value)
		{
		}

		[HttpDelete("{id}")]
		public void Delete(int id)
		{
		}
	}
}
