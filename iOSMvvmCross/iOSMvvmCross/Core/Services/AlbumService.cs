using Core.Models;
using Core.Rest.Interfaces;
using iOSMvvmCross;

namespace Core.Services;

public class AlbumService : IAlbumService
{
    private readonly IRestClient _restClient;

    public AlbumService(IRestClient restClient)
    {
        _restClient = restClient;
    }

    public Task<List<Album>> GetAlbumsAsync(string url = null)
    {
        return string.IsNullOrEmpty(url)
                         ? _restClient.MakeApiCall<List<Album>>($"{ Constants.BaseUrl }/albums/", HttpMethod.Get)
                         : _restClient.MakeApiCall<List<Album>>(url, HttpMethod.Get);
    }
}

