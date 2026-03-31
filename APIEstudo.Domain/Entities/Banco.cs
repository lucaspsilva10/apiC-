using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIEstudo.Domain.Entities
{
    public class Banco
    {
        public Guid Id {  get; private set; }
        public string Nome { get; private set; }
        public DateTime CriadoEm { get; private set; }

        protected Banco() { }
        public Banco(string nome) 
        {
            Id = Guid.NewGuid();
            Nome = nome;
            CriadoEm = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow,
                            TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time"));
        }

        public void UpdateNomeBanco(string nome)
        {
            Nome = nome.ToUpper();
        }
    }
}
