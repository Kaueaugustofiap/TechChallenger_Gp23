
using Microsoft.AspNetCore.Components.Forms;
using WebBlazor.Models;

namespace WebBlazor.Services
{
    public interface IArquivoService { 
        Task<IEnumerable<Arquivo>> GetImagensAsync();
        Task Upload(string arquivo);
    }
}
