using FluentValidation;
using SouJunior.Domain.Entities;

namespace SouJunior.Service.Validators
{
    public class PostagemCreateValidator : AbstractValidator<PostagemEntity>
    {
        public PostagemCreateValidator()
        {
            RuleFor(c => c.PropostaId)
                .NotEmpty().WithMessage("Id de proposta obrigatório")
                .NotNull().WithMessage("Id de proposta obrigatório");
        }
    }
}


