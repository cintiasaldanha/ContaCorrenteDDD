using ContaCorrenteDDD.Domain.Entities;
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ContaCorrenteDDD.Infra.Data.Mapping
{
    public class CorrentistaMap : IEntityTypeConfiguration<Correntista>
	{
        public void Configure(EntityTypeBuilder<Correntista> builder)
        {
        builder.ToTable("Correntista");

        builder.HasKey(c => c.Id);
        
        builder.Property(c => c.NumeroReferencialCliente)
            .IsRequired()
            .HasColumnName("NumeroReferencialCliente");

        builder.Property(c => c.Nome)
            .IsRequired()
            .HasColumnName("Nome");

        builder.Property(c => c.Cpf)
            .IsRequired()
            .HasColumnName("Cpf");

        builder.Property(c => c.Telefone)
            .IsRequired()
            .HasColumnName("Telefone");

        builder.Property(c => c.Endereco)
            .IsRequired()
            .HasColumnName("Endereco");
        }
	}
}