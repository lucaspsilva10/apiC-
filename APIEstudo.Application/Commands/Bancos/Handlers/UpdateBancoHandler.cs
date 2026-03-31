using APIEstudo.Application.Interfaces;
using APIEstudo.Application.Responses;
using APIEstudo.Domain.Interfaces.Bancos;


namespace APIEstudo.Application.Commands.Bancos.Handlers
{
    public class UpdateBancoHandler : ICommandHandler<UpdateBancoCommand, MensagemResponse>
    {
        private readonly IBancoReadRepository _bancoReadRepository;
        private readonly IBancoWriteRepository _bancoWriteRepository;

        public UpdateBancoHandler(IBancoReadRepository bancoReadRepository,
                                  IBancoWriteRepository bancoWriteRepository)
        {
            _bancoReadRepository = bancoReadRepository;
            _bancoWriteRepository = bancoWriteRepository;
        }

        public async Task<MensagemResponse> HandleAsync(UpdateBancoCommand command)
        {
            var banco = await _bancoReadRepository.GetBancoByIdAsync(command.Id)
                        ?? throw new Exception("Banco não encontrado.");

            if (string.IsNullOrEmpty(command.Nome))
                throw new Exception("Digite um nome válido");
         
            if (banco.Nome == command.Nome.ToUpper())
                throw new Exception("Banco já cadastrado");

            banco.UpdateNomeBanco(command.Nome);

            await _bancoWriteRepository.UpdateBancoAsync(banco);

            return new MensagemResponse
            {
                Mensagem = "Nome do Banco atualizado com sucesso"
            };
        }
    }
}
