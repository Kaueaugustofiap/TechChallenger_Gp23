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

        public IEnumerable<Arquivo> ConsultaArquivo()
        {
            var connection = this.GetConnection();

            using (var cn = new SqlConnection(connection))
            {
                var arquivos = cn.Query<Arquivo>("SELECT * FROM TBImagem");
                return arquivos;
            }
        }

        public Arquivo ConsultaArquivo(string url)
        {
            throw new NotImplementedException();
        }
    }
}
