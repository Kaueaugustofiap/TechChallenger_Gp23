using PublicApi.Model;

namespace PublicApi.Repository
{
    public interface IArquivoRepository
    {
        public IEnumerable<Arquivo> ListarArquivos();
        public string UploadImagens(string base64Image);
        public void SalvarImagem(string URI, string fileName);
    }
}
