using PublicApi.Model;

namespace PublicApi.Repository
{
    public interface IArquivoRepository
    {
        public IEnumerable<Arquivo> ListarArquivos();
        public string UploadImagens(string base64Image, string container);
    }
}
