

namespace APIEstudo.Application.Interfaces
{
    public interface ICommandHandler<TCommand>
    {

    }
    public interface ICommandHandler<TCommand, TResult>
    {
        Task<TResult> HandleAsync(TCommand command);
    }
}
