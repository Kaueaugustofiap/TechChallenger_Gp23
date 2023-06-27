using Web.Data;

namespace Web.Services
{
    public class ArquivoService
    {
        private readonly HttpService _httpService;
        private readonly ILogger<ArquivoService> _logger;

        public ArquivoService(HttpService httpService, ILogger<ArquivoService> logger)
        {
            _httpService = httpService;
            _logger = logger;
        }

        public async Task<IEnumerable<Arquivo>> GetImagensAsync()
        {
            var listArquivos = await _httpService.HttpGet<IEnumerable<Arquivo>>($"ConsultaImagens");
            return listArquivos;
        }
    }
}
