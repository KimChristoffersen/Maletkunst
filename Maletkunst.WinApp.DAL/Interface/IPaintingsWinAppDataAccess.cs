using Maletkunst.WinApp.DAL.Model;

namespace Maletkunst.WinApp.ApiClient;

public interface IPaintingsWinAppDataAccess
{
    IEnumerable<Painting> GetAllPaintings();
    int CreatePainting(Painting painting);
    bool DeletePaintingById(int paintingId);
    bool UpdatePainting(Painting painting);
}
