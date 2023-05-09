using Maletkunst.DAL.Interfaces;
using Maletkunst.DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace Maletkunst.MVC.Controllers;

public class PaintingsController : Controller
{
    IPaintingsDataAccess _client;

    public PaintingsController(IPaintingsDataAccess client)
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

    public IActionResult GetPaintingById(int id)
    {

        var getPaintingById = _client.GetPaintingById(id);
        return View("Index", getPaintingById);
    }
}

