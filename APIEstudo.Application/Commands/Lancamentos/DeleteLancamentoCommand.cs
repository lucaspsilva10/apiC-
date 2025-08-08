

namespace APIEstudo.Application.Commands.Lancamentos
{
    public class DeleteLancamentoCommand
    {
        public Guid Id { get; set; }

        public DeleteLancamentoCommand(Guid id) 
        {
            Id = id;
        }
    }
}
