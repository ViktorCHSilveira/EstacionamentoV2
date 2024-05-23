using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities {
    public class Establishment {

        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string CNPJ { get; set; }
        public string Endereço { get; set; }
        public string Telefone { get; set; }
        public int QtdeVagasMotos { get; set; }
        public int QtdeVagasCarros { get; set; }

    }
}
