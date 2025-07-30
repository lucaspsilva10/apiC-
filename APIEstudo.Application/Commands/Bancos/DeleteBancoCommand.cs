using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIEstudo.Application.Commands.Bancos
{
    public class DeleteBancoCommand
    {
        public Guid Id { get; set; }

        public DeleteBancoCommand(Guid id)
        {
            Id = id;
        }
    }
}
