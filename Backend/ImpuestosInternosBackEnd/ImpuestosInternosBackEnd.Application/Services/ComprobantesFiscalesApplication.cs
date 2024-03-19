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
    public class ComprobantesFiscalesApplication : IComprobantesFiscalesApplication
    {
        private readonly IUnitOfWork _unitOfWok;
        private readonly IMapper _mapper;
        private readonly ComprobantesFiscalesValidator _validationRules;

        public ComprobantesFiscalesApplication(IUnitOfWork unitOfWok,
                                               IMapper mapper,
                                               ComprobantesFiscalesValidator validationRules)
        {
            _unitOfWok = unitOfWok;
            _mapper = mapper;
            _validationRules = validationRules;

        }
        public async Task<BaseResponse<IEnumerable<ComprobantesFiscalesResponseDto>>> ListComprobantesFiscales()
        {
            var response = new BaseResponse<IEnumerable<ComprobantesFiscalesResponseDto>>();
            try
            {
                var comprobantesFiscales = await _unitOfWok.ComprobantesFiscales.ListAllComprobantesFiscales();
                if (comprobantesFiscales is not null)
                {
                    response.isSuccess = true;
                    response.Data = _mapper.Map<IEnumerable<ComprobantesFiscalesResponseDto>>(comprobantesFiscales);
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

        public async Task<BaseResponse<bool>> RegisterComprobanteFiscal(ComprobantesFiscalesRequestDto responseDto)
        {
            var response = new BaseResponse<bool>();
            try
            {
                var validationResult = await _validationRules.ValidateAsync(responseDto);

                if (!validationResult.IsValid)
                {
                    response.isSuccess = true;
                    response.Message = ReplayMessage.MESSAGE_VALIDATE;
                    response.Errors = validationResult.Errors;
                }

                var comprobanteFiscal = _mapper.Map<ComprobantesFiscale>(responseDto);
                response.Data = await _unitOfWok.ComprobantesFiscales.RegisterComprobantesFiscales(comprobanteFiscal);

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

        public async Task<BaseResponse<IEnumerable<ComprobantesFiscalesResponseDto>>> SelectComprobantesByCedulaOrRnc(string identifier)
        {
            var response = new BaseResponse<IEnumerable<ComprobantesFiscalesResponseDto>>();
            try
            {
                var selectByIdentifier = await _unitOfWok.ComprobantesFiscales.SelectByCedulaOrRnc(identifier);

                if (selectByIdentifier.Count() > 0)
                {
                    response.isSuccess = true;
                    response.Message = ReplayMessage.MESSAGE_QUERY;
                    response.Data = _mapper.Map<IEnumerable<ComprobantesFiscalesResponseDto>>(selectByIdentifier);

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
    }
}
