using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Academia.Dominio.Aulas.Dtos;

namespace Academia.Dominio.Aulas.Services
{
    public interface IServiceAula
    {
        Task<int> AdicionarAula(NovaAulaDto aula);
        Task<Aula> RecuperarPorCodigoAula(int codigoAula);
    }
}
