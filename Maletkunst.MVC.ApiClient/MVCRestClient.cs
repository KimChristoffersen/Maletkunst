
using Maletkunst.DAL;
using Maletkunst.DAL.Model;
using RestSharp;

namespace RestClient.MVC;


public class MVCRestClient : IPaintingDao
{
	private readonly string restUrl;
	public readonly RestSharp.RestClient client;

	public MVCRestClient()
	{
		
		restUrl = "https://www.maletkunst.dk/api/v1/Paintings";
	
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

}




		