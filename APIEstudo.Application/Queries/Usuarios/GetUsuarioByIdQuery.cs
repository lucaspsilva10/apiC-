using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIEstudo.Application.Queries.Usuarios
{
    public class GetUsuarioByIdQuery
    {
        public Guid Id { get; set; }

        public GetUsuarioByIdQuery(Guid id) 
        {
            Id = id;
        }
    }
}
