using ContaCorrenteDDD.Domain.Entities;
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace ContaCorrenteDDD.Infra.Data.Mapping
{
    public class ContaCorrenteMap
    {
        public void Configure(EntityTypeBuilder<ContaCorrente> builder)
        {
        builder.ToTable("ContaCorrente");

        builder.HasKey(c => c.Id);

        builder.Property(c => c.NumeroConta)
            .IsRequired()
            .HasColumnName("NumeroConta");

        builder.Property(c => c.NumeroReferencialCliente)
            .IsRequired()
            .HasColumnName("NumeroReferencialCliente");

        builder.Property(c => c.Saldo)
            .IsRequired()
            .HasColumnName("Saldo");

        builder.Property(c => c.ValorDebito)
            .HasColumnName("ValorDebito");

        builder.Property(c => c.ValorCredito)
            .HasColumnName("ValorCredito");
        }        
    }
}