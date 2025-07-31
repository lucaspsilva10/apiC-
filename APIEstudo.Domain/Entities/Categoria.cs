using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIEstudo.Domain.Entities
{
    public class Categoria
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public DateTime CriadoEm { get; private set; }

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
