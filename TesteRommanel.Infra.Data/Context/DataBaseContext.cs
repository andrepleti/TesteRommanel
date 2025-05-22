using Microsoft.EntityFrameworkCore;
using TesteRommanel.Domain.Entities;
using TesteRommanel.Infra.Data.Mappings;
using static TesteRommanel.Domain.Entities.BaseEntity;

namespace TesteRommanel.Infra.Data.Context
{
    public class DataBaseContext(DbContextOptions<DataBaseContext> options) : DbContext(options)
    {
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Evento> Eventos { get; set; }

        public override int SaveChanges()
        {
            AddTimestamps();
            return base.SaveChanges();
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            AddTimestamps();
            return await base.SaveChangesAsync(cancellationToken);
        }

        private void AddTimestamps()
        {
            var entities = ChangeTracker.Entries()
                .Where(x => x.Entity is BaseEntity && (x.State == EntityState.Added || x.State == EntityState.Modified));

            foreach (var entity in entities)
            {
                var now = DateTime.UtcNow; // data e hora atual

                if (entity.State == EntityState.Added)
                {
                    ((BaseEntity)entity.Entity).DataCriacao = now;
                    ((BaseEntity)entity.Entity).Status = (byte)EStatus.Ativo;
                }
                ((BaseEntity)entity.Entity).DataModificacao = now;
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Cliente>(new ClienteMap().Configure);
            modelBuilder.Entity<Evento>(new EventoMap().Configure);
        }
    }
}
