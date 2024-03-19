using ImpuestosInternosBackEnd.Application.Dtos.Request;
using ImpuestosInternosBackEnd.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ImpuestoInternosBackend.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContribuyenteController : ControllerBase
    {
        private readonly IContribuyenteApplication _contribuyenteApplication;
        public ContribuyenteController(IContribuyenteApplication contribuyenteApplication)
        {
            _contribuyenteApplication = contribuyenteApplication;
        }

        [HttpGet(nameof(ListSelectContribuyente))]
        public async Task<IActionResult> ListSelectContribuyente()
        {
            var reponse = await _contribuyenteApplication.ListContribuyente();
            return Ok(reponse);
        }

        [HttpPost(nameof(RegisterContribuyente))]
        public async Task<IActionResult> RegisterContribuyente([FromBody] ContribuyenteRequestDto requestDto)
        {
            var reponse = await _contribuyenteApplication.RegisterContribuyentes(requestDto);
            return Ok(reponse);
        }

    }
}
