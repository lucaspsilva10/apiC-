using APIEstudo.Domain.Enums;

namespace APIEstudo.Application.Responses.Lancamentos
{
    public class GetAllLancamentoResponse
    {
        public string NomeUsuario { get;set; }
        public string NomeBanco {  get; set; }
        public string NomeCategoria { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public DateTime DataLancamento { get; set; }
        public TipoLancamento Tipo { get; set; }
        public DateTime DataCriacao { get; set; }
    }
}
