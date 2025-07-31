

namespace APIEstudo.Application.Commands.Categorias
{
    public class DeleteCategoriaCommand
    {
        public Guid Id { get; set; }

        public DeleteCategoriaCommand(Guid id)
        {
            Id = id;
        }
    }
}
