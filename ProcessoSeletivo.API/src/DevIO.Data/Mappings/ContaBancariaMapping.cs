using DevIO.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevIO.Data.Mappings
{
    public class ContaBancariaMapping : IEntityTypeConfiguration<ContaBancaria>
    {
        public void Configure(EntityTypeBuilder<ContaBancaria> builder)
        {
            builder.HasKey(cb => cb.Id);

            builder.Property(cb => cb.NumeroDaConta)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.Property(cb => cb.NumeroDaAgencia)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.Property(cb => cb.CpfCnpj)
                .IsRequired()
                .HasColumnType("varchar(14)");

            builder.Property(cb => cb.NomeRazaoSocialTitular)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.Property(cb => cb.DataAbertura)
                .IsRequired()
                .HasColumnType("datetime");

            builder.Property(cb => cb.Ativo)
                .IsRequired()
                .HasColumnType("bit");

            builder.HasOne(b => b.Banco)
                .WithMany(cb => cb.ContasBancarias)
                .HasForeignKey(cb => cb.BancoId);

            builder.ToTable("ContasBancarias");
        }
    }
}