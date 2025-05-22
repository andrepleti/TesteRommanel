using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TesteRommanel.Domain.Entities;

namespace TesteRommanel.Infra.Data.Mappings
{
    public class EventoMap : IEntityTypeConfiguration<Evento>
    {
        public void Configure(EntityTypeBuilder<Evento> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.ClienteId)
                .IsRequired();

            builder.Property(x => x.TipoEntidade)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(x => x.TipoEvento)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(x => x.Dados)
                .HasMaxLength(5000)
                .IsRequired();

            builder.Property(x => x.Data)
                .IsRequired();

            builder.Property(x => x.Status)
                .IsRequired();

            builder.Property(x => x.DataCriacao)
                .IsRequired();

            builder.Property(x => x.DataModificacao)
                .IsRequired();

            builder.ToTable(nameof(Evento));
        }
    }
}
