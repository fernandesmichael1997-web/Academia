using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Academia.Dominio.Alunos.Dtos;
using FluentValidation;

namespace Academia.Dominio.Alunos.Validador
{
    public class NovoAlunoValidacao : AbstractValidator<NovoAlunoDto>
    {
        public NovoAlunoValidacao() 
        {
            RuleFor(x => x).NotNull()
                .WithMessage("Dados incompletos para cadastro.");

            RuleFor(x => x.TipoPlano)
                .IsInEnum()
                .WithMessage("Tipo do plano inválido.");

            RuleFor(x => x.Nome)
                .NotEmpty()
                .WithMessage("O nome do aluno é obrigatório.");
        }
    }
}
