using Microsoft.AspNetCore.Mvc;
using PublicApi.Model;
using PublicApi.Repository;

namespace PublicApi.Controllers
{
    [Route("[controller]")]
    public class ImagemController : ControllerBase
    {
        private  readonly IArquivoRepository _repository;
        
        public ImagemController(IArquivoRepository repository)
        {
            _repository = repository;
        }

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
