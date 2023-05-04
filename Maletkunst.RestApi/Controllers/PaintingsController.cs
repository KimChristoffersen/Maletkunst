using Microsoft.AspNetCore.Mvc;
using Maletkunst.RestApi.DAL.Model;
using Maletkunst.RestApi.DAL.Interface;

namespace Maletkunst.RestApi.Controllers;

//Routing med eller uden api/{controller}? vi har jo en mappe (serversetup) kaldet api så vi ikke router til api/api/paintings
[Route("v1/[controller]")]
[ApiController]
public class PaintingsController : ControllerBase
{
    private IPaintingMvcDataAccess _paintingMvcDao;
    private IPaintingWinAppDataAccess _paintingWinAppDao;

    public PaintingsController(IPaintingMvcDataAccess paintingMvcDao, IPaintingWinAppDataAccess paintingWinAppDao)
    {
        _paintingMvcDao = paintingMvcDao;
        _paintingWinAppDao = paintingWinAppDao;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Painting>> GetAllAvailable()
    {
        var paintings = _paintingMvcDao.GetAllAvailable();

        if (paintings == null) { return NotFound(); }

        if (!paintings.Any()) { return NoContent(); }

        return Ok(paintings);
    }


    [HttpGet("all")]
    public ActionResult<IEnumerable<Painting>> GetAll()
    {
        var paintings = _paintingWinAppDao.GetAll();

        if (paintings == null) { return NotFound(); }

        if (!paintings.Any()) { return NoContent(); }

        return Ok(paintings);
    }

    [HttpGet("category/{category}")]
    public ActionResult<IEnumerable<Painting>> GetPaintingsByCategory(string category)
    {
        var paintings = _paintingMvcDao.GetAllByCategory(category);

        if (paintings == null) { return NotFound(); }

        if (!paintings.Any()) { return NoContent(); }

        return Ok(paintings);
    }

    [HttpGet("category/{category}/{searchString}")]
    public ActionResult<IEnumerable<Painting>> GetPaintingsByCategoryAndFreeSearch(string category, string searchString)
    {
        var paintings = _paintingMvcDao.GetAllByCategoryAndFreeSearch(category, searchString);

        if (paintings == null) { return NotFound(); }

        if (!paintings.Any()) { return NoContent(); }

        return Ok(paintings);
    }

    [HttpGet("search/{searchString}")]
    public ActionResult<IEnumerable<Painting>> GetPaintingsFreeSearch(string searchString)
    {
        var paintings = _paintingMvcDao.GetAllFreeSearch(searchString);

        if (paintings == null) { return NotFound(); }

        if (!paintings.Any()) { return NoContent(); }

        return Ok(paintings);
    }

    [HttpPost]
    public ActionResult<int> CreatePainting(Painting painting)
    {
        int id = _paintingWinAppDao.CreatePainting(painting);

        if (id == 0) { return BadRequest(); }

        return Ok(id);
    }

    [HttpGet("{id}")]
    public ActionResult<Painting> GetPaintingById(int id)
    {
        Painting paiting = _paintingMvcDao.GetPaintingbyId(id);

        if (paiting == null) { return NotFound(); }

        return Ok(paiting);
    }


    [HttpDelete("delete/{id}")]
    public ActionResult<bool> Delete(int id)
    {
        if (!_paintingWinAppDao.DeletePainting(id))
        {
            return BadRequest();
        }
        return Ok();
    }

    [HttpPut]
    public ActionResult<bool> UpdatePainting(Painting painting)
    {

        if (!_paintingWinAppDao.UpdatePainting(painting)) { return BadRequest(); }

        return Ok(painting);
    }
}
