using Core.Models;

namespace Core.Services;

public interface IAlbumService
{
    Task<List<Album>> GetAlbumsAsync(string url = null);
}

