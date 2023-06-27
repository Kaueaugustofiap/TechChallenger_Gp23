using Microsoft.Extensions.Options;
using System.Text.Json;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace WebBlazor.Services
{
    public class HttpService
    {
        private readonly HttpClient _httpClient;
        private readonly ArquivoService _arquivoService;
        private readonly string _apiUrl;
       public HttpService(HttpClient httpClient, IOptions<BaseUrlConfiguration> baseUrlConfiguration, ArquivoService arquivoService)
        {
            _httpClient = httpClient;
            _arquivoService = arquivoService;
            //_apiUrl = baseUrlConfiguration.Value.ApiBase;
            _apiUrl = "https://localhost:7032/";
        }

        public async Task<T> HttpGet<T>(string uri)
            where T : class
        {
            //_apiUrl = "https://localhost:7032/";
            uri = "Imagem/ConsultaImagens";

            var result = await _httpClient.GetAsync($"{_apiUrl}{uri}");
            if (!result.IsSuccessStatusCode)
            {
                return null;
            }

            return await FromHttpResponseMessage<T>(result);
        }
        
        //public async Task<T> HttpPost<T>(string uri, object dataToSend)
        //    where T : class
        //{
        //    var content = ToJson(dataToSend);

        //    var result = await _httpClient.PostAsync($"{_apiUrl}{uri}", content);
        //    if (!result.IsSuccessStatusCode)
        //    {
        //        var exception = JsonSerializer.Deserialize<ErrorDetails>(await result.Content.ReadAsStringAsync(), new JsonSerializerOptions
        //        {
        //            PropertyNameCaseInsensitive = true
        //        });
        //        _toastService.ShowToast($"Error : {exception.Message}", ToastLevel.Error);

        //        return null;
        //    }

        //    return await FromHttpResponseMessage<T>(result);
        //}

        private StringContent ToJson(object obj)
        {
            return new StringContent(JsonSerializer.Serialize(obj), Encoding.UTF8, "application/json");
        }

        private async Task<T> FromHttpResponseMessage<T>(HttpResponseMessage result)
        {
            return JsonSerializer.Deserialize<T>(await result.Content.ReadAsStringAsync(), new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
        }
    }
}
