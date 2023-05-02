using Maletkunst.WinApp.DAL.Model;
using RestSharp;

namespace Maletkunst.WinApp.ApiClient;

public class PaintingsRestClient : IPaintingsRestClient
{
    RestSharp.RestClient restClient = new RestSharp.RestClient("https://www.maletkunst.dk/api/v1");
    //RestClient restClient = new RestClient("https://localhost:7064/v1");


    public IEnumerable<Painting> GetAll()
    {
        var request = new RestRequest("paintings/all", Method.Get);
        var response = restClient.Execute<List<Painting>>(request);
        return response.Data;
    }

    public int CreatePainting(Painting painting)
    {
        var request = new RestRequest("paintings", Method.Post).AddJsonBody(painting);
        var response = restClient.Execute<int>(request);
        return response.Data;
    }

    public bool DeletePainting(int paintingId)
    {
        var request = new RestRequest($"paintings/delete/{paintingId}", Method.Delete);
        var response = restClient.Execute<bool>(request);

        if (!response.IsSuccessful) { return false; }
        return true;

    }
}