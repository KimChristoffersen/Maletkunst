using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestClient.MVC;
using RestSharp;
using System.Xml.Linq;
using Maletkunst.DAL.Model;
using Maletkunst.DAL;

namespace Maletkunst.MVC.Controllers
{
	public class PaintingsController : Controller
	{
		IPaintingDao _client;

		public PaintingsController(IPaintingDao client)
		{
			_client = client;
		}
		// GET: PaintingsController
		public IActionResult Index(string searchString)
		{
			IEnumerable<Painting> paintings;
			if (!string.IsNullOrEmpty(searchString))
			{
				paintings = _client.Search(searchString);
			}
			else
			{
				paintings = _client.GetAllPaintings();
			}
			if (paintings == null)
			{
				return NotFound();
			}

			return View(paintings);

		}




		public IActionResult GetPaintingsByCategory(string category)
		{
			var getPaintingsByCategory = _client.GetPaintingsByCategory(category);
			return View("Index", getPaintingsByCategory);

		}




	}

}

