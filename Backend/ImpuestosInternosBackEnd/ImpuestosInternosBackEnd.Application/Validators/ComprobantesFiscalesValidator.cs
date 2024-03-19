using FluentValidation;
using ImpuestosInternosBackEnd.Application.Dtos.Request;
namespace ImpuestosInternosBackEnd.Application.Validators
{
    public  class ComprobantesFiscalesValidator : AbstractValidator<ComprobantesFiscalesRequestDto>
    {
        public ComprobantesFiscalesValidator()
        {
            RuleFor(x => x.RncCedula)
              .NotNull().WithMessage("El campo RNC/CEDULA no puede ser nulo")
              .NotEmpty().WithMessage("El campo RNC/CEDULA no puede ser vacio");


            RuleFor(x => x.Ncf)
             .NotNull().WithMessage("El campo NCF no puede ser nulo")
             .NotEmpty().WithMessage("El campo NCF no puede ser vacio");

            RuleFor(x => x.Monto)
             .NotNull().WithMessage("El campo Monto no puede ser nulo")
             .NotEmpty().WithMessage("El campo Monto no puede ser vacio");
        }
    }
}
