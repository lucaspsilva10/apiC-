using APIEstudo.Application.Interfaces;
using APIEstudo.Application.Responses;
using APIEstudo.Domain.Entities;
using APIEstudo.Domain.Interfaces.Bancos;

namespace APIEstudo.Application.Commands.Bancos.Handlers
{
    public class CreateBancoHandler : ICommandHandler<CreateBancoCommand, MensagemResponse>
    {
        private readonly IBancoWriteRepository _bancoWriteRepository;
        private readonly IBancoReadRepository _bancoReadRepository;

        public CreateBancoHandler(IBancoWriteRepository bancoWriteRepository,
                                  IBancoReadRepository bancoReadRepository)
        {
            _bancoWriteRepository = bancoWriteRepository;
            _bancoReadRepository = bancoReadRepository;
        }

        public async Task<MensagemResponse> HandleAsync(CreateBancoCommand command)
        {
            var nome = command.Nome.ToUpper();

            if (await _bancoReadRepository.ValidateBancoExistAsync(nome))
                throw new Exception("Banco já cadastrado.");

            var banco = new Banco(nome);
            await _bancoWriteRepository.CreateBancoAsync(banco);

            return new MensagemResponse { Mensagem = "Banco criado com sucesso" };
        }
    }
}
