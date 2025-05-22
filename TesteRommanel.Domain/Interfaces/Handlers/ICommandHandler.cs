namespace TesteRommanel.Domain.Interfaces.Handlers
{
    public interface ICommandHandler<TEntity>
    {
        bool Handle(TEntity command);
    }
}
