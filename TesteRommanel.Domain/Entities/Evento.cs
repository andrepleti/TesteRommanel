namespace TesteRommanel.Domain.Entities
{
    public class Evento : BaseEntity
    {
        public long ClienteId { get; set; } = 0;

        public string TipoEntidade { get; set; } = string.Empty;

        public string TipoEvento { get; set; } = string.Empty;

        public string Dados { get; set; } = string.Empty;

        public DateTime Data { get; set; }
    }
}
