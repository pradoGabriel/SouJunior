using FluentValidation;
using SouJunior.Domain.Entities;

namespace SouJunior.Service.Validators
{
    public class PropostaCreateValidator : AbstractValidator<PropostaEntity>
    {
        public PropostaCreateValidator()
        {
            RuleFor(c => c.Titulo)
                .NotEmpty().WithMessage("Título obrigatório")
                .NotNull().WithMessage("Título obrigatório");

            RuleFor(c => c.Descricao)
                .NotEmpty().WithMessage("Descrição obrigatória")
                .NotNull().WithMessage("Descrição obrigatória");

        }
    }
}
