

using APIEstudo.Domain.Enums;

namespace APIEstudo.Domain.Entities
{
    public class Lancamento
    {
        public Guid Id { get; private set; }
        public Guid UsuarioId { get; private set; }
        public Guid BancoId { get; private set; }
        public Guid CategoriaId { get; private set; }
        public string Descricao { get; private set; }
        public decimal Valor {  get; private set; }
        public DateTime DataLancamento { get; private set; }
        public TipoLancamento Tipo { get; private set; }
        public DateTime CriadoEm { get; private set; }

        protected Lancamento() { }

        public Lancamento(Guid usuarioId, Guid bancoId, Guid categoriaId, string? descricao, decimal valor, DateTime dataLancamento, TipoLancamento tipo)
        {
            Id = Guid.NewGuid();
            UsuarioId = usuarioId;
            BancoId = bancoId;
            CategoriaId = categoriaId;
            Descricao = descricao.ToUpper();
            Valor = valor;
            DataLancamento = dataLancamento;
            Tipo = tipo;
            CriadoEm = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow,
                            TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time"));
        }

        public void AtualizarLancamento(Guid bancoId, Guid categoriaId, string descricao, decimal valor, DateTime dataLancamento, TipoLancamento tipo)
        {
            BancoId = bancoId;
            CategoriaId = categoriaId;
            Descricao = descricao.ToUpper();
            Valor = valor;
            DataLancamento = dataLancamento;
            Tipo = tipo;
        }
    }
}
