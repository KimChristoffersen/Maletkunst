using Maletkunst.MVC.DAL.Interface;
using Maletkunst.MVC.DAL.Model;
using RestSharp;
using static System.Net.WebRequestMethods;

namespace Maletkunst.MVC.ApiClient;


public class PaintingRestApiClient : IPaintingMvcDataAccess
{
    private readonly string restUrl;
    public readonly RestSharp.RestClient client;

    public PaintingRestApiClient()
    {

        restUrl = "https://www.maletkunst.dk/api/v1/Paintings";
        //restUrl = "https://localhost:7150/v1/Paintings";

        client = new RestSharp.RestClient(restUrl);
    }

    public IEnumerable<Painting> GetAllAvailablePaintings()
    {
        var request = new RestRequest();
        var response = client.Execute<IEnumerable<Painting>>(request);
        return response.Data;
    }

    public IEnumerable<Painting> GetAllPaintingsByFreeSearch(string searchString)
    {
        var request = new RestRequest($"search/{searchString}", Method.Get);
        var response = client.Execute<IEnumerable<Painting>>(request);
        return response.Data;
    }

    public IEnumerable<Painting> GetAllPaintingsByCategory(string category)
    {
        var request = new RestRequest($"category/{category}", Method.Get);
        var response = client.Execute<IEnumerable<Painting>>(request);
        return response.Data;
    }

    public Painting GetPaintingById(int id)
    {
        var request = new RestRequest($"{id}", Method.Get);
        var response = client.Execute<Painting>(request);
        return response.Data;
    }

}




