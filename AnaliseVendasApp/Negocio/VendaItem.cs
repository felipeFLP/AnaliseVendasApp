﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnaliseVendasApp.Negocio
{
    public class VendaItem
    {

        public Venda Venda { get; set; }
        public Item Item { get; set; }

        public int Quantity { get; set; }
        public double Price { get; set; }

        public VendaItem()
        {

        }

    }
}
