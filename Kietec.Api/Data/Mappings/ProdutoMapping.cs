using Kietec.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kietec.Api.Data.Mappings;

//Cria o mapeamento de um Produto no banco de dados
public class ProdutoMapping : IEntityTypeConfiguration<Produto>
{
    public void Configure(EntityTypeBuilder<Produto> builder)
    {
        builder.ToTable("Produto");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Nome)
            .IsRequired()
            .HasColumnType("NVARCHAR")
            .HasMaxLength(80);

        builder.Property(x => x.Descricao)
            .IsRequired()
            .HasColumnType("NVARCHAR")
            .HasMaxLength(120);

        builder.Property(x => x.Preco)
            .IsRequired()
            .HasColumnType("MONEY");

        builder.Property(x => x.DataCriacao)
            .IsRequired(); //Cria data com tipo DATETIME2

        builder
            .HasIndex(x => x.Nome)
            .IsUnique();
        
        //Estabelecendo a relação 1 pra N entre fornecedor e produto
        builder
            .HasOne(x => x.Fornecedor)
            .WithMany(x => x.Produtos);
    }
}