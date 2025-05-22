namespace TesteRommanel.Domain.Entities
{
    public abstract class BaseEntity
    {
        public long Id { get; set; } = 0;
        public byte Status { get; set; } = (byte)EStatus.Ativo;
        public DateTime DataCriacao { get; set; } = new DateTime();
        public DateTime DataModificacao { get; set; } = new DateTime();

        public enum EStatus
        {
            Ativo = 1,
            Deletado = 2
        }
    }
}
