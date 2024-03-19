using AutoMapper;
using ImpuestosInternosBackEnd.Application.Dtos.Request;
using ImpuestosInternosBackEnd.Application.Dtos.Response;
using ImpuestosInternosBackEnd.Domain.Entities;
using ImpuestosInternosBackEnd.Utilities.Static;

namespace ImpuestosInternosBackEnd.Application.Mappers
{
    public class ContribuyenteMappingProfile : Profile
    {
        public ContribuyenteMappingProfile()
        {
            CreateMap<Contribuyente, ContribuyenteResponseDto>()
                .ForMember(x => x.Estatus, x => x.MapFrom(y => y.Estatus.Equals((int)StateTypes.Active) ? "Inactivo" : "Activo"))
                .ReverseMap();

            CreateMap<ContribuyenteResponseDto, Contribuyente>();
            CreateMap<ContribuyenteRequestDto, Contribuyente>();
        }
    }
}
