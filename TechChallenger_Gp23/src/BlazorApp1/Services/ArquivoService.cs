
using Microsoft.AspNetCore.Components.Forms;
using System.Net;
using System.Net.Http.Json;
using System.Security.Policy;
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
                // Criar o conteúdo da requisição com o corpo (body) em formato JSON
                //var content = new StringContent("{\"imagem\": \"" + arquivo + "\"}", Encoding.UTF8, "application/json");
                var content = new StringContent(arquivo);

                using (HttpClient client = new HttpClient())
                {
                    // Enviar a solicitação POST
                    HttpResponseMessage response = await client.PostAsync("Imagem/UploadImagem", content);

                    // Lidar com a resposta
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
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
