using Maletkunst.RestApi.DAL.Model;

namespace Maletkunst.RestApi.DAL.Interface;

public interface IPaintingWinAppDataAccess
{
    IEnumerable<Painting> GetAllPaintings();
    int CreatePainting(Painting painting);
    bool DeletePaintingById(int id);
    bool UpdatePainting(Painting painting);
}