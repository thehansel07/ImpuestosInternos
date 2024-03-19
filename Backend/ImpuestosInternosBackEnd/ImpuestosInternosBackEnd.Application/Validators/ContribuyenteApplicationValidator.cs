using FluentValidation;
using ImpuestosInternosBackEnd.Application.Dtos.Request;
namespace ImpuestosInternosBackEnd.Application.Validators
{
    public class ContribuyenteApplicationValidator : AbstractValidator<ContribuyenteRequestDto>
    {
        public ContribuyenteApplicationValidator()
        {
            RuleFor(x => x.RncCedula)
              .NotNull().WithMessage("El campo RNC/CEDULA no puede ser nulo")
              .NotEmpty().WithMessage("El campo RNC/CEDULA no puede ser vacio");
              

            RuleFor(x => x.Nombre)
              .NotNull().WithMessage("El campo Nombre no puede ser nulo")
              .NotEmpty().WithMessage("El campo Nombre no puede ser vacio");

            RuleFor(x => x.Tipo)
             .NotNull().WithMessage("El campo Tipo no puede ser nulo")
             .NotEmpty().WithMessage("El campo Tipo no puede ser vacio");

            RuleFor(x => x.Estatus)
             .NotNull().WithMessage("El campo Estatus no puede ser nulo")
             .NotEmpty().WithMessage("El campo Estatus no puede ser vacio");
        }
    }
}
