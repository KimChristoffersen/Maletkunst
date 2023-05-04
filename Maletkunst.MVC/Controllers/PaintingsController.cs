using Maletkunst.MVC.DAL.Interface;
using Maletkunst.MVC.DAL.Model;
using Microsoft.AspNetCore.Mvc;

namespace Maletkunst.MVC.Controllers;

public class PaintingsController : Controller
{
    IPaintingMvcDataAccess _client;

    public PaintingsController(IPaintingMvcDataAccess client)
    {
        _client = client;
    }
    // GET: PaintingsController
    public IActionResult Index(string searchString)
    {
        IEnumerable<Painting> paintings;
        if (!string.IsNullOrEmpty(searchString)) { paintings = _client.GetAllPaintingsByFreeSearch(searchString); }
        else { paintings = _client.GetAllAvailablePaintings(); }
        
        if (paintings == null) { return NotFound(); }

        return View(paintings);
    }

    public IActionResult GetPaintingsByCategory(string category)
    {
        var getPaintingsByCategory = _client.GetAllPaintingsByCategory(category);
        return View("Index", getPaintingsByCategory);
    }

    public IActionResult Details(int id)
    {
        var painting = _client.GetPaintingById(id);
        return View(painting);
    }
}

