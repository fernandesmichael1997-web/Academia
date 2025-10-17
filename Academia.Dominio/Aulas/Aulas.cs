
namespace Academia.Dominio.Aulas
{
    public class Aula
    {
        public int Id { get; set; }
        public EnumTipoAula TipoAula { get; set; }
        public DateTime DataHora { get; set; }
        public int CapacidadeMaxima { get; set; }
    }
    public enum EnumTipoAula
    {
        Cross = 1,
        Funcional = 2,
        Pilates = 3,
        Musculacao = 4
    }
}
