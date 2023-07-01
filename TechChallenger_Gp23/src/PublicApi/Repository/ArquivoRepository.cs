using Dapper;
using Microsoft.Extensions.Configuration;
using PublicApi.Model;
using System.Data.SqlClient;

namespace PublicApi.Repository
{
    public class ArquivoRepository : IArquivoRepository
    {
        private readonly IConfiguration _configuration;

        public ArquivoRepository(IConfiguration configuration)
        {
            this._configuration = configuration;
        }

        public string GetConnection()
        {
            var conn = _configuration.GetSection("AppConnection").Value;
            return conn;
        }

        public IEnumerable<Arquivo> ListarArquivos()
        {
            var connection = this.GetConnection();

            using (var cn = new SqlConnection(connection))
            {

                //var arquivos = cn.Query<Arquivo>("SELECT * FROM TBImagem");
                var arquivos = new List<Arquivo>();
                arquivos.Add(new Arquivo() { Id = 1, Nome = "Teste", URL = "teste.png" });
                arquivos.Add(new Arquivo() { Id = 2, Nome = "Teste", URL = "teste.png" });
                arquivos.Add(new Arquivo() { Id = 3, Nome = "Teste", URL = "teste.png" });
                arquivos.Add(new Arquivo() { Id = 4, Nome = "Teste", URL = "~/techChallengeIcon.png" });

                return arquivos;
            }
        }
    }
}
