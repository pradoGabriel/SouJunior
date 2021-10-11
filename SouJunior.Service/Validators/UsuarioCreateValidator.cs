using FluentValidation;
using SouJunior.Domain.Entities;

namespace SouJunior.Service.Validators
{
    public class UsuarioCreateValidator : AbstractValidator<UsuarioEntity>
    {
        public UsuarioCreateValidator()
        {
            RuleFor(c => c.Nome)
                .NotEmpty().WithMessage("Nome obrigatório")
                .NotNull().WithMessage("Nome obrigatório");

            RuleFor(c => c.Email)
                .NotEmpty().WithMessage("E-mail obrigatório")
                .NotNull().WithMessage("E-mail obrigatório");

            RuleFor(c => c.Senha)
                .NotEmpty().WithMessage("Senha obrigatória")
                .NotNull().WithMessage("Senha obrigatória");
        }
    }
}
