namespace E_Commerce_Api.API;

public class ApiConsume : IApiConsume
{

    private readonly string baseAddress;
    private HttpClient Client;

    public ApiConsume(IConfiguration configuration)
    {
        string baseAddress = configuration.GetSection("api")["baseUrl"];
        Client = new HttpClient();
        Client.BaseAddress = new Uri(baseAddress);



    }


    public bool Create(string apiName, object o)
    {
        var postTask = Client.PostAsJsonAsync(apiName, o);
        postTask.Wait();
        var res = postTask.Result;
        return res.IsSuccessStatusCode;

    }

    public bool Delete(string apiName)
    {
        var postTask = Client.DeleteAsync(apiName);
        postTask.Wait();
        var res = postTask.Result;
        return res.IsSuccessStatusCode;
    }

    public IEnumerable<T> GetAll<T>(string apiName)
    {
        var res = Client.GetAsync(apiName).Result;
        var data = res.Content.ReadAsAsync<IEnumerable<T>>().Result;
        return data;
    }

    public object? GetAll()
    {
        throw new NotImplementedException();
    }

    public object GetAll<T>(object value)
    {
        throw new NotImplementedException();
    }

    public object GetAsync(string v)
    {
        throw new NotImplementedException();
    }

    public T GetById<T>(string apiName)
    {
        var res = Client.GetAsync(apiName).Result;
        var data = res.Content.ReadAsAsync<T>().Result;
        return data;
    }

    public bool Update(string apiName, object o)
    {
        var postTask = Client.PutAsJsonAsync(apiName, o);
        postTask.Wait();
        var res = postTask.Result;
        return res.IsSuccessStatusCode;
    }
}