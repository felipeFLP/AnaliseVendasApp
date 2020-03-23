using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnaliseVendasApp.Negocio;

namespace AnaliseVendasApp.Dados
{
    public class ItemConfiguration : IEntityTypeConfiguration<Item>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Item> builder)
        {


            builder
                .ToTable("Item");

            builder
                .Property(i => i.Id)
                .HasColumnName("Id")
                .IsRequired();







        }
    }
}
