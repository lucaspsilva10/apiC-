using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIEstudo.Domain.Entities
{
    public class Usuario
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Email {  get; set; }
        public string Senha { get; set; }
        public string TipoUsuario { get; set; } 
        public DateTime CriadoEm { get; set; }
    }
}
