using ImpuestosInternosBackEnd.Application.Commons.Bases;
using ImpuestosInternosBackEnd.Application.Dtos.Request;
using ImpuestosInternosBackEnd.Application.Dtos.Response;

namespace ImpuestosInternosBackEnd.Application.Interfaces
{
    public interface IComprobantesFiscalesApplication
    {
        Task<BaseResponse<bool>> RegisterComprobanteFiscal(ComprobantesFiscalesRequestDto responseDto);
        Task<BaseResponse<IEnumerable<ComprobantesFiscalesResponseDto>>> ListComprobantesFiscales();
        Task<BaseResponse<IEnumerable<ComprobantesFiscalesResponseDto>>> SelectComprobantesByCedulaOrRnc(string identifier);
    }
}
