using AnaliseVendasApp.Negocio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnaliseVendasApp.Dados
{
    public class VendedorConfiguration : IEntityTypeConfiguration<Vendedor>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Vendedor> builder)
        {
            builder
                .ToTable("Vendedor");

            builder
                .Property(v => v.Id)
                .HasColumnName("Id")
                .HasColumnType("varchar(11)")
                .IsRequired();


            builder
                .Property(v => v.Name)
                .HasColumnName("name")
                .HasColumnType("varchar(100)");

            builder
                .Property(v => v.Salary)
                .HasColumnName("salary")
                .HasColumnType("float");

            
        }
    }
}
