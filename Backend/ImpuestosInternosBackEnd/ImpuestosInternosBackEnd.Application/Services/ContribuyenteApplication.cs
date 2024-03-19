using AutoMapper;
using ImpuestosInternosBackEnd.Application.Commons.Bases;
using ImpuestosInternosBackEnd.Application.Dtos.Request;
using ImpuestosInternosBackEnd.Application.Dtos.Response;
using ImpuestosInternosBackEnd.Application.Interfaces;
using ImpuestosInternosBackEnd.Application.Validators;
using ImpuestosInternosBackEnd.Domain.Entities;
using ImpuestosInternosBackEnd.Infrastructure.Persistence.Interfaces;
using ImpuestosInternosBackEnd.Utilities.Static;

namespace ImpuestosInternosBackEnd.Application.Services
{
    public class ContribuyenteApplication : IContribuyenteApplication
    {
        private readonly IUnitOfWork _unitOfWok;
        private readonly IMapper _mapper;
        private readonly ContribuyenteApplicationValidator _validationRules;
        public ContribuyenteApplication(IUnitOfWork unitOfWok,
                                        IMapper mapper,
                                        ContribuyenteApplicationValidator validationRules)
        {
            _unitOfWok = unitOfWok;
            _mapper = mapper;
            _validationRules = validationRules;
        }

        public async Task<BaseResponse<IEnumerable<ContribuyenteResponseDto>>> ListContribuyente()
        {


            var response = new BaseResponse<IEnumerable<ContribuyenteResponseDto>>();

            try
            {
                var contribuyente = await _unitOfWok.Contribuyentes.ListAllContribuyentes();
                if (contribuyente is not null)
                {
                    response.isSuccess = true;
                    response.Data = _mapper.Map<IEnumerable<ContribuyenteResponseDto>>(contribuyente);
                    response.Message = ReplayMessage.MESSAGE_QUERY;
                }
                else
                {
                    response.isSuccess = false;
                    response.Message = ReplayMessage.MESSAGE_QUERY_EMPTY;
                }
            }
            catch (Exception ex)
            {
                response.isSuccess = false;
                response.Message = ReplayMessage.MESSAGE_EXCEPTION;
                WatchDog.WatchLogger.Log(ex.Message);
            }

            return response;
        }

        public async Task<BaseResponse<bool>> RegisterContribuyentes(ContribuyenteRequestDto responseDto)
        {
            var response = new BaseResponse<bool>();
            try
            {
                var validationResult = await _validationRules.ValidateAsync(responseDto);
                if (!validationResult.IsValid)
                {
                    response.isSuccess = false;
                    response.Message = ReplayMessage.MESSAGE_VALIDATE;
                    response.Errors = validationResult.Errors;
                }

                var comprobanteFiscal = _mapper.Map<Contribuyente>(responseDto);
                response.Data = await _unitOfWok.Contribuyentes.RegisterContribuyente(comprobanteFiscal);

                if (response.Data)
                {
                    response.isSuccess = true;
                    response.Message = ReplayMessage.MESSAGE_SAVE;

                }
                else
                {
                    response.isSuccess = false;
                    response.Message = ReplayMessage.MESSAGE_FAILED;
                }

            }
            catch (Exception ex)
            {
                response.isSuccess = false;
                response.Message = ReplayMessage.MESSAGE_EXCEPTION;
                WatchDog.WatchLogger.Log(ex.Message);
            }
            return response;
        }
    }
}
