using Kietec.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kietec.Api.Data.Mappings;

//Cria o mapeamento de um Fornecedor no banco de dados
public class FornecedorMapping : IEntityTypeConfiguration<Fornecedor>
{
    public void Configure(EntityTypeBuilder<Fornecedor> builder)
    {
        builder.ToTable("Fornecedor");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Nome)
            .IsRequired()
            .HasColumnType("NVARCHAR")
            .HasMaxLength(80);

        builder.Property(x => x.Telefone)
            .IsRequired()
            .HasColumnType("VARCHAR");

        builder
            .HasIndex(x => x.Nome)
            .IsUnique();       
    }
}