using Microsoft.AspNetCore.Mvc;
using Maletkunst.RestApi.DAL.Model;
using Maletkunst.RestApi.DAL.DataAccess;

namespace Maletkunst.RestApi.Controllers;

//Routing med eller uden api/{controller}? vi har jo en mappe (serversetup) kaldet api så vi ikke router til api/api/paintings
[Route("v1/[controller]")]
[ApiController]
public class PaintingsController : ControllerBase
{
    private IPaintingDAO _paintingDAO;
    public PaintingsController(IPaintingDAO paintingDAO) => _paintingDAO = paintingDAO;

    [HttpGet]
    public ActionResult<IEnumerable<Painting>> GetAllAvailable()
    {
        var paintings = _paintingDAO.GetAllAvailable();

        if (paintings == null) { return NotFound(); }

        if (!paintings.Any()) { return NoContent(); }

        return Ok(paintings);
    }


    [HttpGet("all")]
    public ActionResult<IEnumerable<Painting>> GetAll()
    {
        var paintings = _paintingDAO.GetAll();

        if (paintings == null) { return NotFound(); }

        if (!paintings.Any()) { return NoContent(); }

        return Ok(paintings);
    }

    [HttpGet("category/{category}")]
    public ActionResult<IEnumerable<Painting>> GetPaintingsByCategory(string category)
    {
        var paintings = _paintingDAO.GetAllByCategory(category);

        if (paintings == null) { return NotFound(); }

        if (!paintings.Any()) { return NoContent(); }

        return Ok(paintings);
    }

    [HttpGet("category/{category}/{searchString}")]
    public ActionResult<IEnumerable<Painting>> GetPaintingsByCategoryAndFreeSearch(string category, string searchString)
    {
        var paintings = _paintingDAO.GetAllByCategoryAndFreeSearch(category, searchString);

        if (paintings == null) { return NotFound(); }

        if (!paintings.Any()) { return NoContent(); }

        return Ok(paintings);
    }

    [HttpGet("search/{searchString}")]
    public ActionResult<IEnumerable<Painting>> GetPaintingsFreeSearch(string searchString)
    {
        var paintings = _paintingDAO.GetAllFreeSearch(searchString);

        if (paintings == null) { return NotFound(); }

        if (!paintings.Any()) { return NoContent(); }

        return Ok(paintings);
    }

    [HttpPost]
    public ActionResult<int> CreatePainting(Painting painting)
    {
        int id = _paintingDAO.CreatePainting(painting);

        if (id == 0) { return BadRequest(); }

        return Ok(id);
    }

    [HttpGet("{id}")]
    public ActionResult<Painting> GetPaintingById(int id)
    {
        Painting paiting = _paintingDAO.GetPaintingbyId(id);

        if (paiting == null) { return NotFound(); }

        return Ok(paiting);
    }


    [HttpDelete("delete/{id}")]
    public ActionResult<bool> Delete(int id)
    {
        if (!_paintingDAO.DeletePainting(id))
        {
            return BadRequest();
        }
        return Ok();
    }

    [HttpPut]
    public ActionResult<bool> UpdatePainting(Painting painting)
    {

        if (!_paintingDAO.UpdatePainting(painting)) { return BadRequest(); }

        return Ok(painting);
    }
}
