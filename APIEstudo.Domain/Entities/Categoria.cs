

namespace APIEstudo.Domain.Entities
{
    public class Categoria
    {
        public Guid Id { get; private set; }
        public string Nome { get; private set; }
        public DateTime CriadoEm { get; private set; }

        protected Categoria() { }
        public Categoria(string nome) 
        {
            Id = Guid.NewGuid();
            Nome = nome.ToUpper();
            CriadoEm = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow,
                            TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time"));
        }

        public void UpdateNome(string nome)
        {
            Nome = nome.ToUpper();
        }

    }
}
