using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academia.Dominio.Alunos
{
    public class Aluno
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public EnumTipoPlano TipoPlano { get; set; }
    }
    public enum EnumTipoPlano 
    {
        Mensal = 1,
        Trimestral = 2,
        Anual = 3
    }
}
