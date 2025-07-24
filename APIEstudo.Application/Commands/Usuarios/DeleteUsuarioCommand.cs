

namespace APIEstudo.Application.Commands.Usuarios
{
    public class DeleteUsuarioCommand
    {
        public Guid Id { get; set; }

        public DeleteUsuarioCommand(Guid id) 
        {
            Id = id;
        }
    }
}
