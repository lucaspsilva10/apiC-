using APIEstudo.Application.Interfaces;
using APIEstudo.Application.Responses;
using APIEstudo.Domain.Entities;
using APIEstudo.Domain.Interfaces.Categorias;

namespace APIEstudo.Application.Commands.Categorias.Handlers
{
    public class CreateCategoriaHandler : ICommandHandler<CreateCategoriaCommand, MensagemResponse>
    {
        private readonly ICategoriaWriteRepository _categoriaWriteRepository;
        private readonly ICategoriaReadRepository _categoriaReadRepository;

        public CreateCategoriaHandler(ICategoriaWriteRepository categoriaWriteRepository,
                                      ICategoriaReadRepository categoriaReadRepository)
        {
            _categoriaWriteRepository = categoriaWriteRepository;
            _categoriaReadRepository = categoriaReadRepository;
        }

        public async Task<MensagemResponse> HandleAsync(CreateCategoriaCommand command)
        {
            var nome = command.Nome.ToUpper();

            if (await _categoriaReadRepository.ValidateCategoriaExistAsync(nome))
                throw new Exception("Categoria já cadastrada");

            var categoria = new Categoria(nome);
            await _categoriaWriteRepository.CreateCategoriaAsync(categoria);

            return new MensagemResponse() { Mensagem = "Categoria criada com sucesso" };
        }
    }
}
