using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnaliseVendasApp.Negocio
{
    public class Venda
    {

        public int Id { get; set; }
        
        public Vendedor Vendedor { get; set; }

        public IList<VendaItem> Items { get; set; }

        public Venda()
        {
            Items = new List<VendaItem>();
        }

        public Venda(int id, Vendedor vendedor)
        {
            Items = new List<VendaItem>();

            this.Id = id;
           
            this.Vendedor = vendedor;
        }

        public void IncluiItem(Item item)
        {
            Items.Add( new VendaItem() { Item = item } );
        }





    }
}
