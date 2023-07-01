
using WebBlazor.Models;

namespace WebBlazor.Services
{
    public interface IArquivoService { 
        Task<IEnumerable<Arquivo>> GetImagensAsync();
    }
}
