using Maletkunst.RestApi.DAL.Model;

namespace Maletkunst.RestApi.DAL.Interface;

public interface IPaintingMvcDataAccess
{
    IEnumerable<Painting> GetAllAvailablePaintings();
    IEnumerable<Painting> GetAllPaintingsByFreeSearch(string searchString);
    IEnumerable<Painting> GetAllPaintingsByCategory(string category);
    IEnumerable<Painting> GetAllPaintingsByCategoryAndFreeSearch(string category, string searchString);
    Painting GetPaintingById(int id);
}