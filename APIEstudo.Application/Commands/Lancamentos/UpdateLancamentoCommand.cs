using APIEstudo.Domain.Enums;

namespace APIEstudo.Application.Commands.Lancamentos
{
    public class UpdateLancamentoCommand
    {
        public Guid LancamentoId { get; set; }
        public string NomeBanco { get; set; }
        public string NomeCategoria { get; set; }
        public string Descricao { get; set; }
        public decimal Valor {  get; set; }
        public TipoLancamento TipoLancamento { get; set; }
        public DateTime DataLancamento { get; set; }
    }
}
