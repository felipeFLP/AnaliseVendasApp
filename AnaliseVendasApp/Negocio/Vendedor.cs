using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnaliseVendasApp.Negocio
{
    public class Vendedor
    {


        public string Id { get; set; }
        public string Name { get; set; }
        public double Salary { get; set; }

        public IList<Venda> Vendas { get; set; }

        public Vendedor()
        {
            Vendas = new List<Venda>();
        }

        public Vendedor(string cpf, string name, double salary)
        {
            this.Id = cpf;
            this.Name = name;
            this.Salary = salary;

        }


    }
}
