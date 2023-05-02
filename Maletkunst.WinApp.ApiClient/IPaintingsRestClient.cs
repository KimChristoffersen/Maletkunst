using Maletkunst.WinApp.DAL.Model;

namespace Maletkunst.WinApp.ApiClient;

public interface IPaintingsRestClient
{
    IEnumerable<Painting> GetAll();
    int CreatePainting(Painting painting);
    bool DeletePainting(int paintingId);
}
