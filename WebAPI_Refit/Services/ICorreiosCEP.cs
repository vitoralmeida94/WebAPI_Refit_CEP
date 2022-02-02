using Refit;
using WebAPI_Refit.Models;

namespace WebAPI_Refit.Services
{
    public interface ICorreiosCEP
    {
        [Get("/ws/{cepCode}/json")]
        Task<CepResponse> Get([AliasAs("cepCode")]string cepCode);
    }
}
