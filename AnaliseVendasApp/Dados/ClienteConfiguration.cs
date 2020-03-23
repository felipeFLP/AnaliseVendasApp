using AnaliseVendasApp.Negocio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnaliseVendasApp.Dados
{
    public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Cliente> builder)
        {
            builder
                .ToTable("Cliente");

            builder
                .Property(c => c.Id)
                .HasColumnName("Id")
                .HasColumnType("varchar(14)");

            builder
                .Property(c => c.Name)
                .HasColumnName("name")
                .HasColumnType("varchar(100)");

            builder
                .Property(c => c.BusinessArea)
                .HasColumnName("businessArea")
                .HasColumnType("varchar(100)");

            //builder.HasKey("cnpj");



        }
    }
}
