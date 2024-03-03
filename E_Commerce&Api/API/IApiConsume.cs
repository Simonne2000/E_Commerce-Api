namespace E_Commerce_Api.API;

public interface IApiConsume
{

    IEnumerable<T> GetAll<T>(string apiName);
    T GetById<T>(string apiName);
    public bool Create(string apiName, object o);
    public bool Delete(string apiName);
    public bool Update(string apiName, object o);
    object? GetAll();
    object GetAll<T>(object value);
    object GetAsync(string v);
}