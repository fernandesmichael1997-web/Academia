using Academia.Dominio.Aulas.Dtos;
using Academia.Dominio.Aulas.Validador;

namespace Academia.Dominio.Aulas.Services
{
    public class ServiceAula : IServiceAula
    {
        private readonly IRepositorioAulas _repositorioAulas;

        public ServiceAula(IRepositorioAulas repositorioAulas)
        {
            _repositorioAulas = repositorioAulas;
        }
        public async Task<int> AdicionarAula(NovaAulaDto aula)
        {
            ValidarCadastroAula(aula);
            try
            {
                var aulaNova = new Aula()
                {
                    TipoAula = aula.TipoAula,
                    DataHora = aula.DataHora,
                    CapacidadeMaxima = aula.CapacidadeMaxima
                };

                await _repositorioAulas.Adicionar(aulaNova);

                return aulaNova.Id;
            }
            catch (Exception ex)
            {
                throw new Exception("Falha ao cadastrar nova aula. ", ex);
            }
        }
        public async Task<Aula> RecuperarPorCodigoAula(int codigoAula)
        {
            return await _repositorioAulas.RecuperarPorCodigoAula(codigoAula);
        }
        private void ValidarCadastroAula(NovaAulaDto aula)
        {
            var validar = new NovaAulaValidacao();
            var retorno = validar.Validate(aula);

            if (!retorno.IsValid)
            {
                throw new ArgumentException(string.Join(" | ", retorno.Errors.Select(e => e.ErrorMessage)));
            }
        }
    }
}
