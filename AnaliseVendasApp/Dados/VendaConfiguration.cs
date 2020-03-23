using AnaliseVendasApp.Negocio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnaliseVendasApp.Dados
{
    public class VendaConfiguration : IEntityTypeConfiguration<Venda>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Venda> builder)
        {
            builder
                .ToTable("Venda");

            builder
                .Property(v => v.Id)
                .HasColumnName("Id")
                .HasColumnType("int")
                .IsRequired();
            
                        

            builder.Property<string>("vendedorId");

            builder.HasOne(ve => ve.Vendedor)
                .WithMany(va => va.Vendas)
                .HasForeignKey("vendedorId");



        }
    }
}
