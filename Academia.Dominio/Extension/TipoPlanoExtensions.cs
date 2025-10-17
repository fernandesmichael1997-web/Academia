using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Academia.Dominio.Alunos;

namespace Academia.Dominio.Extension
{
    public static class TipoPlanoExtensions
    {
        public static int LimiteMensal(this EnumTipoPlano plano)
        {
            return plano switch
            {
                EnumTipoPlano.Mensal => 12,
                EnumTipoPlano.Trimestral => 20,
                EnumTipoPlano.Anual => 30,
                _ => throw new ArgumentOutOfRangeException(nameof(plano), "Tipo do Plano inválido")
            };
        }
    }
}
