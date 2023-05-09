using Maletkunst.DAL.Models;

namespace Maletkunst.DAL.Interfaces;

public interface IPaintingsDao
{
    IEnumerable<Painting> GetAllPaintings();
    int CreatePainting(Painting painting);
    bool DeletePaintingById(int id);
    bool UpdatePainting(Painting painting);
}