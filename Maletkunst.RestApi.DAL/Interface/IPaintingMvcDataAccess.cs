using Maletkunst.RestApi.DAL.Model;

namespace Maletkunst.RestApi.DAL.Interface;

public interface IPaintingMvcDataAccess
{
    IEnumerable<Painting> GetAllAvailable();
    IEnumerable<Painting> GetAllFreeSearch(string searchString);
    IEnumerable<Painting> GetAllByCategory(string category);
    IEnumerable<Painting> GetAllByCategoryAndFreeSearch(string category, string searchString);
    Painting GetPaintingbyId(int id);
}