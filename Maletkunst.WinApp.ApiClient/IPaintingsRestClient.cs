using ClientApp.DAL.Model;

namespace ClientApp.DAL.Client;

public interface IPaintingsRestClient
{
    IEnumerable<Painting> GetAll();
    int CreatePainting(Painting painting);
    bool DeletePainting(int paintingId);
}
