namespace TesteRommanel.Application.Commands
{
    public class ClienteDeletarCommand(long id)
    {
        public long Id { get; set; } = id;
    }
}
