using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Academia.Dominio.Aulas;

namespace Academia.Dominio.Alunos.Dtos
{
    public class RetornoRelatorioAlunoDto
    {
        public int CodigoAluno { get; set; }
        public string Nome { get; set; }
        public int TotalAulasNoMes { get; set; }
        public List<TipoAulaFrequenteDto> TiposDeAulaMaisFrequentes { get; set; }
    }
    public class TipoAulaFrequenteDto
    {
        public string TipoAula { get; set; }
        public int Total { get; set; }
    }

}
