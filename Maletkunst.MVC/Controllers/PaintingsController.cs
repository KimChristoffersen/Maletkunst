using Maletkunst.MVC.DAL;
using Maletkunst.MVC.DAL.Model;
using Microsoft.AspNetCore.Mvc;

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

        public IActionResult Details(int id)
        {
            var painting = _client.GetPaintingById(id);
       

            return View(painting);
        }


    }

}

