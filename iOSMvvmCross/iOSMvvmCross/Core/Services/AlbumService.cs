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
        return _restClient.MakeApiCall<List<Album>>($"{Constants.BaseUrl}/albums/", HttpMethod.Get);
    }

    public Task<List<Photo>> GetPhotosAsync()
    {
        return _restClient.MakeApiCall<List<Photo>>($"{Constants.BaseUrl}/photos/", HttpMethod.Get);
    }
}

