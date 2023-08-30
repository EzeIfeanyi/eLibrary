using eLibrary.Models.Enums;

namespace eLibrary.Services
{
    public class DataServices 
    {
        private readonly HttpClient _client;
        private readonly string BaseUrl;
        public DataServices(HttpClient client, IConfiguration config)
        {
            _client = client;
            BaseUrl = config.GetSection("BaseUrl").Value!;
        }

        public async Task<U?> MakeRequest<U, T>(MethodType method, string url, T data)
        {
            if (string.IsNullOrEmpty(url)) throw new ArgumentNullException("address");

            HttpResponseMessage apiResult = new HttpResponseMessage();

            switch (method)
            {
                case MethodType.Get:
                    apiResult = await _client.GetAsync(BaseUrl + url);
                    break;

                case MethodType.Post:
                    apiResult = await _client.PostAsJsonAsync(BaseUrl + url, data);
                    break;

                case MethodType.Put:
                    apiResult = await _client.PutAsJsonAsync(BaseUrl + url, data);
                    break;

                case MethodType.Delete:
                    apiResult = await _client.DeleteAsync(BaseUrl + url);
                    break;
                default:
                    break;
            }

            if (apiResult != null)
            {
                if (apiResult.IsSuccessStatusCode)
                {
                    if (apiResult.Content != null)
                    {
                        var result = await apiResult.Content.ReadFromJsonAsync<U>();
                        if (result != null)
                            return result;
                    }
                }
            }

            return default;
        }

        public void Dispose()
        {
            _client.Dispose();
        }
    }
}
