using Maletkunst.DAL.Interfaces;
using Maletkunst.DAL.Models;
using RestSharp;

namespace Maletkunst.DAL.RestClient;

public class PaintingsDao : IPaintingsDao
{
    RestSharp.RestClient restClient = new RestSharp.RestClient("https://www.maletkunst.dk/api/v1");
    //RestClient restClient = new RestClient("https://localhost:7150/v1");


    public IEnumerable<Painting> GetAllPaintings()
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

    public bool DeletePaintingById(int paintingId)
    {
        var request = new RestRequest($"paintings/delete/{paintingId}", Method.Delete);
        var response = restClient.Execute<bool>(request);

        if (!response.IsSuccessful) { return false; }
        return true;

    }

    public bool UpdatePainting(Painting painting)
    {
        var request = new RestRequest("paintings", Method.Put).AddJsonBody(painting);
        var response = restClient.ExecuteAsync<bool>(request);

        response.Wait();

        if (!response.IsCompleted) { return false; }
        return true;


    }
}