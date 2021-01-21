using DevIO.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevIO.Data.Mappings
{
    public class BancoMapping : IEntityTypeConfiguration<Banco>
    {
        public void Configure(EntityTypeBuilder<Banco> builder)
        {
            builder.HasKey(b => b.Id);

            builder.Property(b => b.CodigoBanco)
                .IsRequired()
                .HasColumnType("varchar(50)");

            builder.Property(b => b.NomeInstituicao)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.ToTable("Bancos");
        }
    }
}