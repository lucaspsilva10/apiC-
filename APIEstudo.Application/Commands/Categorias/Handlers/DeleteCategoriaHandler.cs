
using APIEstudo.Application.Interfaces;
using APIEstudo.Application.Responses;
using APIEstudo.Domain.Interfaces.Categorias;

namespace APIEstudo.Application.Commands.Categorias.Handlers
{
    public class DeleteCategoriaHandler : ICommandHandler<DeleteCategoriaCommand, MensagemResponse>
    {
        private readonly ICategoriaWriteRepository _categoriaWriteRepository;

        public DeleteCategoriaHandler(ICategoriaWriteRepository categoriaWriteRepository)
        {
            _categoriaWriteRepository = categoriaWriteRepository;
        }

        public async Task<MensagemResponse> HandleAsync(DeleteCategoriaCommand command)
        {
            var deleteCategoria = await _categoriaWriteRepository.DeleteCategoriaAsync(command.Id);

            if (!deleteCategoria)
                throw new Exception("Categoria não encontrada");

            return new MensagemResponse { Mensagem = "Categoria deletada com sucesso" };
        }
    }
}
