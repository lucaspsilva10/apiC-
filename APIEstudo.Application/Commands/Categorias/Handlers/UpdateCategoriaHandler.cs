using APIEstudo.Application.Interfaces;
using APIEstudo.Application.Responses;
using APIEstudo.Domain.Entities;
using APIEstudo.Domain.Interfaces.Categorias;

namespace APIEstudo.Application.Commands.Categorias.Handlers
{
    public class UpdateCategoriaHandler : ICommandHandler<UpdateCategoriaCommand, MensagemResponse>
    {
        private readonly ICategoriaReadRepository _categoriaReadRepository;
        private readonly ICategoriaWriteRepository _categoriaWriteRepository;

        public UpdateCategoriaHandler(ICategoriaReadRepository categoriaReadRepository,
                                      ICategoriaWriteRepository categoriaWriteRepository)
        {
            _categoriaReadRepository = categoriaReadRepository;
            _categoriaWriteRepository = categoriaWriteRepository;
        }

        public async Task<MensagemResponse> HandleAsync(UpdateCategoriaCommand command)
        {
            var categoria = await _categoriaReadRepository.GetCategoriaByIdAsync(command.Id)
                ?? throw new ArgumentException("Categoria não encontrada");

            if (string.IsNullOrEmpty(command.Nome))
                throw new ArgumentException("Digite um nome válido de categoria");

            categoria.UpdateNome(command.Nome);

            await _categoriaWriteRepository.UpdateCategoriaAsync(categoria);

            return new MensagemResponse { Mensagem = "Noma da Categoria atualizado com sucesso" };
        }
    }
}
