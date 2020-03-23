using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnaliseVendasApp.Negocio
{
    public class Cliente
    {

        public string Id { get; set; }
        public string Name { get; set; }
        public string BusinessArea { get; set; }

        public Cliente(string cnpj, string name, string businessArea)
        {
            this.Id = cnpj;
            this.Name = name;
            this.BusinessArea = businessArea;

        }

        public Cliente()
        {

        }





    }
}
