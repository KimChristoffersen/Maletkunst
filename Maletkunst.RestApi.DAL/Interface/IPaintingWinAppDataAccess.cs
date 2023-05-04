using Maletkunst.RestApi.DAL.Model;

namespace Maletkunst.RestApi.DAL.Interface;

public interface IPaintingWinAppDataAccess
{
    IEnumerable<Painting> GetAll();
    int CreatePainting(Painting painting);
    bool DeletePainting(int id);
    bool UpdatePainting(Painting painting);
}