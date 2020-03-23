using AnaliseVendasApp.Negocio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnaliseVendasApp.Dados
{
    public class VendaItemConfiguration : IEntityTypeConfiguration<VendaItem>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<VendaItem> builder)
        {



            builder.ToTable("VendaItem");

            builder.Property<int>("vendaId").IsRequired();
            builder.Property<int>("itemId").IsRequired();

            builder
                .Property(i => i.Quantity)
                .HasColumnName("quantity")
                .HasColumnType("int");

            builder
                .Property(i => i.Price)
                .HasColumnName("price")
                .HasColumnType("float");


            builder.HasKey("vendaId", "itemId");

            builder.HasOne(v => v.Item)
                .WithMany(i => i.Vendas)
                .HasForeignKey("itemId");

            builder.HasOne(i => i.Venda)
                .WithMany(v => v.Items)
                .HasForeignKey("vendaId");



        }
    }
}
