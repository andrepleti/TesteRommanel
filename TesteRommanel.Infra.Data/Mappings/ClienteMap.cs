using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TesteRommanel.Domain.Entities;

namespace TesteRommanel.Infra.Data.Mappings
{
    public class ClienteMap : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.NomeRazaoSocial)
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(x => x.CpfCnpj)
                .HasMaxLength(14)
                .IsRequired();

            builder.Property(x => x.InscricaoEstadual)
                .HasMaxLength(15)
                .IsRequired(false);

            builder.Property(x => x.Isento)
                .IsRequired();

            builder.Property(x => x.DataNascimento)
                .IsRequired(false);

            builder.Property(x => x.Telefone)
                .HasMaxLength(11)
                .IsRequired();

            builder.Property(x => x.Email)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(x => x.Tipo)
                .IsRequired();

            builder.Property(x => x.Cep)
                .HasMaxLength(8)
                .IsRequired();

            builder.Property(x => x.Logradouro)
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(x => x.Numero)
                .HasMaxLength(5)
                .IsRequired();

            builder.Property(x => x.Bairro)
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(x => x.Cidade)
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(x => x.Estado)
                .HasMaxLength(2)
                .IsRequired();

            builder.Property(x => x.Status)
                .IsRequired();

            builder.Property(x => x.DataCriacao)
                .IsRequired();

            builder.Property(x => x.DataModificacao)
                .IsRequired();

            builder.ToTable(nameof(Cliente));
        }
    }
}
