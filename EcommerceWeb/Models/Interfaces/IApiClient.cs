using CommonEnitity.Catalog;

namespace WebEcommerce.Models.Interfaces;
public interface IApiClient
{
    Task<T> PostAsync<T>(string apiPath, object jsonContent);
    Task<T> PostAsync<T>(string apiPath, object jsonContent, 
        bool addClientHeader = false, 
        bool accessToken = false);
    Task<IEnumerable<T>> PostListAsync<T>(string apiPath, object jsonContent);
    Task<T> PostAsync<T>(string apiPath, object jsonContent, 
        Dictionary<string, string> headerParam, 
        bool addClientHeader = false, 
        bool accessToken = false);
    Task<T> GetAsync<T>();
    Task<T> GetAsync<T>(string apiPath);
    Task<T> GetAsync<T>(string apiPath, 
        bool addClientHeader = false, 
        bool accessToken = false);
    Task<T> GetAsync<T>(string apiPath, 
        Dictionary<string, string> headerParam, 
        bool addClientHeader = false, 
        bool accessToken = false);
    Task PostVoidAsync(string apiPath, object jsonContent);
}

