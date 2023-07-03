using Azure.Storage.Blobs;
using Dapper;
using Microsoft.Extensions.Configuration;
using PublicApi.Model;
using System.Data.SqlClient;
using System.Reflection;
using System.Text.RegularExpressions;

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
                var arquivos = cn.Query<Arquivo>("SELECT * FROM TBImagem");

                return arquivos;
            }
        }

        public string UploadImagens(string base64Image)
        {
            var BlobStorage = _configuration.GetSection("BlobStorage").Value;

            // Gera um nome randomico para imagem
            var fileName = Guid.NewGuid().ToString() + ".jpg";

            // Limpa o hash enviado
            var data = new Regex(@"^data:image\/[a-z]+;base64,").Replace(base64Image, "");

            // Gera um array de Bytes
            byte[] imageBytes = Convert.FromBase64String(data);

            // Define o BLOB no qual a imagem será armazenada
            var blobClient = new BlobClient(BlobStorage, "dados", fileName);

            // Envia a imagem
            using (var stream = new MemoryStream(imageBytes))
            {
                blobClient.Upload(stream);
            }

            // Retorna a URL da imagem
            var blobUri = blobClient.Uri.AbsoluteUri;

            SalvarImagem(blobUri, fileName);

            return blobUri;
        }

        public void SalvarImagem(string URI, string fileName)
        {
            var connection = this.GetConnection();

            using (var cn = new SqlConnection(connection))
            {
                var sql = @"INSERT INTO TBImagem (NOME, URL) VALUES (@fileName, @URI)";
                cn.Execute(sql, new { URI, fileName });
            }

        }
    }
}
