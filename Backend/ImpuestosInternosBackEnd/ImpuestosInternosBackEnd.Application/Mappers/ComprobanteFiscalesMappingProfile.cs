using AutoMapper;
using ImpuestosInternosBackEnd.Application.Dtos.Request;
using ImpuestosInternosBackEnd.Application.Dtos.Response;
using ImpuestosInternosBackEnd.Domain.Entities;

namespace ImpuestosInternosBackEnd.Application.Mappers
{
    public class ComprobanteFiscalesMappingProfile : Profile
    {
        public ComprobanteFiscalesMappingProfile()
        {

            CreateMap<ComprobantesFiscalesRequestDto, ComprobantesFiscale>();

            CreateMap<ComprobantesFiscalesResponseDto, ComprobantesFiscale>()
                .ReverseMap();
        }
    }
}
