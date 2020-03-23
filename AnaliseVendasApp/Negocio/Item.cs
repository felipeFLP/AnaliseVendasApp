using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnaliseVendasApp.Negocio
{
    public class Item
    {

        public int Id { get; set; }


        public IList<VendaItem> Vendas { get; set; }

        public Item()
        {
            Vendas = new List<VendaItem>();
        }

        public Item(int id)
        {
            Vendas = new List<VendaItem>();
            this.Id = id;           
        }

    }
}
