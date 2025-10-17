using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academia.Dominio.Aulas
{
    public interface IRepositorioAulas
    {
        Task Adicionar(Aula aula);
        Task<Aula> RecuperarPorCodigoAula(int codigoAula);
    }
}
