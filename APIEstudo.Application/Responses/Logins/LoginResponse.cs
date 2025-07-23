using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIEstudo.Application.Responses.Logins
{
    public class LoginResponse
    {
        public string Token {  get; set; }
        public DadosUsuarioLogado Usuario { get; set; }
    }

    public class DadosUsuarioLogado
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
    }
}
