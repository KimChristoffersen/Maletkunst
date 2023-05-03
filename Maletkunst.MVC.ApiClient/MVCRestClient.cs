using Maletkunst.MVC.DAL;
using Maletkunst.MVC.DAL.Model;
using RestSharp;
using static System.Net.WebRequestMethods;

namespace Maletkunst.MVC.ApiClient;


public class MVCRestClient : IPaintingDao
{
    private readonly string restUrl;
    public readonly RestSharp.RestClient client;

    public MVCRestClient()
    {

        restUrl = "https://www.maletkunst.dk/api/v1/Paintings";
        //restUrl = "https://localhost:7150/v1/Paintings";

        client = new RestSharp.RestClient(restUrl);
    }

    public IEnumerable<Painting> GetAllPaintings()
    {
        var request = new RestRequest();
        return client.Get<IEnumerable<Painting>>(request);

    }

    public IEnumerable<Painting> Search(string searchString)
    {
        var request = new RestRequest($"search/{searchString}", Method.Get);
        var response = client.Execute<IEnumerable<Painting>>(request);
        return response.Data;
    }

    public IEnumerable<Painting> GetPaintingsByCategory(string category)
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




