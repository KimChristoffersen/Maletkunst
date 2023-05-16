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
	//public IActionResult Index(string category, string searchString)
	//{
	//	IEnumerable<Painting> paintings;

	//	if (!string.IsNullOrEmpty(searchString))
	//	{
	//		if (!string.IsNullOrEmpty(category))
	//		{
	//			paintings = _client.GetAllPaintingsByFreeSearch(searchString).Where(p => p.Category == category);
	//		}
	//		else
	//		{
	//			paintings = _client.GetAllPaintingsByFreeSearch(searchString);
	//		}
	//	}
	//	else if (!string.IsNullOrEmpty(category))
	//	{
	//		paintings = _client.GetAllPaintingsByCategory(category);
	//	}
	//	else
	//	{
	//		paintings = _client.GetAllAvailablePaintings();
	//	}

	//	ViewData["Category"] = category;
	//	ViewData["SearchString"] = searchString;
	//	return View(paintings);
	//}

	public IActionResult Index(string category, string searchString)
	{
		var paintings = _client.GetAllPaintingsByFreeSearch(searchString, category);
		ViewData["Category"] = category ?? string.Empty;
		ViewData["SearchString"] = searchString ?? string.Empty;
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