using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIEstudo.Application.Commands.Bancos
{
    public class UpdateBancoCommand
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
    }
}
