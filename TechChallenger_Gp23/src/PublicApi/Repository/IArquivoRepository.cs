using PublicApi.Model;

namespace PublicApi.Repository
{
    public interface IArquivoRepository
    {
        public IEnumerable<Arquivo> ConsultaArquivo();

        public Arquivo ConsultaArquivo(string url);
    }
}
