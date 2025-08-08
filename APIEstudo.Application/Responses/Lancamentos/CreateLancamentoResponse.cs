using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIEstudo.Application.Responses.Lancamentos
{
    public class CreateLancamentoResponse
    {
        public string NomeBanco { get; set; }
        public string NomeCategoria { get; set; }
        public string Descricao { get; set; }
        public decimal Valor {  get; set; }
        public DateTime DataLancamento { get; set; }
    }
}
