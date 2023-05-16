using Maletkunst.DAL.Models;

namespace Maletkunst.DAL.Interfaces
{
    public interface IPaintingsDataAccess
    {
        IEnumerable<Painting> GetAllAvailablePaintings();
        IEnumerable<Painting> GetAllPaintingsByFreeSearch(string searchString);
        IEnumerable<Painting> GetAllPaintingsByCategory(string category);
        //IEnumerable<Painting> GetAllPaintingsByCategoryAndFreeSearch(string category, string searchString); Not yet implemented in mvc
        Painting GetPaintingById(int id);

        IEnumerable<Painting> GetAllPaintingsByFreeSearch(string searchString, string category);


	}
}
