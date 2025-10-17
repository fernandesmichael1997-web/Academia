using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academia.Dominio.Alunos.Dtos
{
    public class NovoAlunoDto
    {
        public string Nome { get; set; }
        public EnumTipoPlano TipoPlano { get; set; }
    }
}
