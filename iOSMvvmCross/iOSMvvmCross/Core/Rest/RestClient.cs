using System.Text;
using MvvmCross.Base;
using Core.Rest.Interfaces;
using System.Text.Json;

namespace SCore.Rest.Implementations;

public class RestClient : IRestClient
{
    public RestClient(/*, IMvxLog mvxLog*/)
    {
        //_mvxLog = mvxLog;
    }

    public async Task<TResult> MakeApiCall<TResult>(string url, HttpMethod method, object data = null) where TResult : class
    {
        url = url.Replace("http://", "https://");

        using (var httpClient = new HttpClient())
        {
            using (var request = new HttpRequestMessage { RequestUri = new Uri(url), Method = method })
            {
                // add content
                if (method != HttpMethod.Get)
                {
                    var json = JsonSerializer.Serialize(data);
                    request.Content = new StringContent(json, Encoding.UTF8, "application/json");
                }

                HttpResponseMessage response = new HttpResponseMessage();
                try
                {
                    response = await httpClient.SendAsync(request).ConfigureAwait(false);
                }
                catch (Exception ex)
                {
                    //_mvxLog.ErrorException("MakeApiCall failed", ex);
                }

                var stringSerialized = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };
                return JsonSerializer.Deserialize<TResult>(stringSerialized, options);
            }
        }
    }
}
