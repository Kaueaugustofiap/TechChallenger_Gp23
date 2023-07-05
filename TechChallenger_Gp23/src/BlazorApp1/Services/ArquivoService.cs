using Newtonsoft.Json;
using System.Net.Http.Json;
using System.Text;
using WebBlazor.Models;

namespace WebBlazor.Services
{
    public class ArquivoService : IArquivoService
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


        public async Task Upload(string arquivo)
        {
            try
            {
                var content = new StringContent(JsonConvert.SerializeObject(arquivo), Encoding.UTF8, "application/json");

                HttpResponseMessage response = await httpClient.PostAsync("Imagem/UploadImagem", content);

                if (response.IsSuccessStatusCode)
                {
                    string responseContent = await response.Content.ReadAsStringAsync();
                    Console.WriteLine("Resposta do servidor: " + responseContent);
                }
                else
                {
                    Console.WriteLine("Falha na solicitação. Código de status: " + response.StatusCode);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
