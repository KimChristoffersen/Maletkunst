using Maletkunst.DAL.Models;

namespace Maletkunst.DAL.Interfaces;

public interface IPaintingWinAppDataAccess
{
    IEnumerable<Painting> GetAllPaintings();
    int CreatePainting(Painting painting);
    bool DeletePaintingById(int id);
    bool UpdatePainting(Painting painting);
}