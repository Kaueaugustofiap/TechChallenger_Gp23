using Microsoft.AspNetCore.Mvc;
using PublicApi.Model;
using PublicApi.Repository;

namespace PublicApi.Controllers
{
   // [ApiController]
    [Route("[controller]")]
    public class ImagemController : ControllerBase
    {
        private  readonly IArquivoRepository _repository;
        private readonly ILogger<ImagemController> _logger;

        public ImagemController(IArquivoRepository repository, ILogger<ImagemController> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        //private static readonly string[] Summaries = new[]
        //{
        //    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        //};


        //[HttpGet("GetWeatherForecast")]
        //public IEnumerable<WeatherForecast> GetWeatherForecast()
        //{
        //    return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        //    {
        //        Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
        //        TemperatureC = Random.Shared.Next(-20, 55),
        //        Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        //    })
        //    .ToArray();
        //}

        [HttpGet("ConsultaImagens")]
        public IEnumerable<Arquivo> ConsultaImagens()
        {
            return _repository.ListarArquivos().ToArray();
        }

        [HttpPost("UploadImagem")]
        public string UploadImagens(string base64Image, string container)
        {
            return _repository.UploadImagens(base64Image, container);
        }
    }
}
