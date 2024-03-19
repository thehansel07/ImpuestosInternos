using ImpuestosInternosBackEnd.Application.Dtos.Request;
using ImpuestosInternosBackEnd.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ImpuestoInternosBackend.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComprobantesFiscalesController : ControllerBase
    {
        private readonly IComprobantesFiscalesApplication _comprobantesFiscalesApplication;
        public ComprobantesFiscalesController(IComprobantesFiscalesApplication comprobantesFiscalesApplication)
        {
            _comprobantesFiscalesApplication = comprobantesFiscalesApplication;
        }

        [HttpGet(nameof(ListAllComprobanteFiscales))]
        public async Task<IActionResult> ListAllComprobanteFiscales()
        {
            var response = await _comprobantesFiscalesApplication.ListComprobantesFiscales();
            return Ok(response);
        }

        [HttpPost(nameof(RegisterComprobantesFiscales))]
        public async Task<IActionResult> RegisterComprobantesFiscales([FromBody] ComprobantesFiscalesRequestDto requestDto)
        {
            var response = await _comprobantesFiscalesApplication.RegisterComprobanteFiscal(requestDto);
            return Ok(response);
        }

        [HttpGet("[action]/{Identifier}")]
        public async Task<IActionResult> GetComprobantesFiscalesByIdentifier(string Identifier)
        {
            var response = await _comprobantesFiscalesApplication.SelectComprobantesByCedulaOrRnc(Identifier);
            return Ok(response);
        }
    }
}
