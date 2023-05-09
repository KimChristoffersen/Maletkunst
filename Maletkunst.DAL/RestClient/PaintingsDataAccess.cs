using Maletkunst.DAL.Interfaces;
using Maletkunst.DAL.Models;
using RestSharp;

namespace Maletkunst.DAL.RestClient;


public class PaintingsDataAccess : IPaintingsDataAccess
{
    private readonly string restUrl;
    public readonly RestSharp.RestClient client;

    public PaintingsDataAccess()
    {

        restUrl = "https://www.maletkunst.dk/api/v1/Paintings";
        //restUrl = "https://localhost:7150/v1/Paintings";

        //Robert URL nedenunder
        //restUrl = "https://localhost:7104/Paintings";

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

    //public Painting GetPaintingById(int id)
    //{
    //    var request = new RestRequest($"{id}", Method.Get);
    //    var response = client.Execute<Painting>(request);
    //    return response.Data;
    //}

    public Painting GetPaintingById(int id)
    {
        var request = new RestRequest("{id}");
        request.AddUrlSegment("id", id);
        var response = client.Execute<Painting>(request);
        return response.Data;
    }
}




