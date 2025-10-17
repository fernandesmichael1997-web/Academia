

namespace Academia.Dominio.Aulas.Dtos
{
    public class NovaAulaDto
    {
        public EnumTipoAula TipoAula { get; set; }
        public DateTime DataHora { get; set; }
        public int CapacidadeMaxima { get; set; }
    }
}
