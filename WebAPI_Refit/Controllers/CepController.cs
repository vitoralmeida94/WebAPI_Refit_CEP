using Microsoft.AspNetCore.Mvc;
using WebAPI_Refit.Services;

namespace WebAPI_Refit.Controllers
{
    [ApiController]
    public class CepController : ControllerBase
    {
        private readonly ICorreiosCEP _correiosCEP;
        public CepController(ICorreiosCEP correiosCEP)
        {
            _correiosCEP = correiosCEP;
        }

        [HttpGet("v1/cep/{cep}")]
        public async Task<IActionResult> Get([FromRoute] string cep)
        {
            try
            {
                if (cep == null)
                    return BadRequest();

                var response = await _correiosCEP.Get(cep);

                if (response == null)
                    return NotFound();

                return Ok(response);
            }
            catch
            {
                return BadRequest(new { result = "Ocorreu um erro com API do Correios. Verifique o cep digitado."});
            }
        }
    }
}
