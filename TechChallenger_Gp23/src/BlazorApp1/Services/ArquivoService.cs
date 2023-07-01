
using System.Net.Http.Json;
using WebBlazor.Models;

namespace WebBlazor.Services
{
    public class ArquivoService: IArquivoService
    {
        private readonly HttpClient httpClient;

        public ArquivoService(HttpClient _httpClient)
        {
            this.httpClient = _httpClient;
        }

        public async Task<IEnumerable<Arquivo>> GetImagensAsync()
        {
            try
            {
                var response = await httpClient.GetAsync("Imagem/ConsultaImagens");

                if (response.IsSuccessStatusCode)
                {
                    var arquivos = await response.Content.ReadFromJsonAsync<IEnumerable<Arquivo>>();
                    return arquivos;
                }
                return new List<Arquivo>();
            }
            catch (Exception ex)
            {
               throw;
            }
        }
    }
}
