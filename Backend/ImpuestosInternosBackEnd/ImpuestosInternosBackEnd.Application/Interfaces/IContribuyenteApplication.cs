using ImpuestosInternosBackEnd.Application.Commons.Bases;
using ImpuestosInternosBackEnd.Application.Dtos.Request;
using ImpuestosInternosBackEnd.Application.Dtos.Response;

namespace ImpuestosInternosBackEnd.Application.Interfaces
{
    public interface IContribuyenteApplication
    {
        Task<BaseResponse<bool>> RegisterContribuyentes(ContribuyenteRequestDto responseDto);
        Task<BaseResponse<IEnumerable<ContribuyenteResponseDto>>> ListContribuyente();
    }
}
