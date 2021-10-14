using SouJunior.Domain.Entities;
using Swashbuckle.AspNetCore.Filters;

namespace SouJunior.Api.RequestExamples
{
    public class CreateUsuarioExample : IExamplesProvider<UsuarioEntity>
    {
        public UsuarioEntity GetExamples()
        {
            var estudante = new EstudanteEntity()
            {
                Cpf = "11111111",
                Curso = "ADS",
                Instituicao = "Fatec",
                Periodo = Domain.Enums.PeriodoEnum.Noite
            };

            var endereco = new EnderecoEntity()
            {
                Cep = "08485280",
                Cidade = "São Paulo",
                Bairro = "Cidade Tirandes",
                Complemento = "Campo de futebol",
                Logradouro = "Rua da Sorte",
                Estado = "SP",
                Numero = "15"
            };

            return new UsuarioEntity()
            {
                Nome = "Gabriel",
                Email = "gabriel@email.com",
                Senha = "teste",
                Telefone = "11 11111111",
                Estudante = estudante,
                Endereco = endereco
            };
        }
    }
}
