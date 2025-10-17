using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Academia.Dominio.Aulas.Dtos;
using FluentValidation;

namespace Academia.Dominio.Aulas.Validador
{
    public class NovaAulaValidacao : AbstractValidator<NovaAulaDto>
    {
        public NovaAulaValidacao()
        {
            RuleFor(x => x).NotNull()
                .WithMessage("Dados incompletos para cadastro.");

            RuleFor(x => x.TipoAula)
                .IsInEnum()
                .WithMessage("Tipo de aula inválido.");

            RuleFor(x => x.DataHora)
                .GreaterThan(DateTime.Now)
                .WithMessage("A data e hora da aula não podem ser no passado.");

            RuleFor(x => x.CapacidadeMaxima)
                .GreaterThan(0)
                .WithMessage("A capacidade máxima deve ser maior que zero.");
        }
    }
}

