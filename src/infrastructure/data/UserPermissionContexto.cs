using UserPermission.core.entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace UserPermission.infrastructure.data
{
    public class UserPermissionContexto : DbContext
    {
        private IDbContextTransaction contextoTransaction;

        public UserPermissionContexto(DbContextOptions<UserPermissionContexto> options) : base(options) { }

        public DbSet<UserPermissionEntity> UserPermissionEntity { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            CargarDatosIniciales(modelBuilder);
        }

        public virtual void IniciarTransaccion()
        {
            contextoTransaction = Database.BeginTransaction();
        }

        public virtual void ConfirmarTransaccion()
        {
            try
            {
                SaveChanges();
                contextoTransaction.Commit();
            }
            finally
            {
                contextoTransaction.Dispose();
            }
        }

        public virtual void RevertirTransaccion()
        {
            if (contextoTransaction != null)
            {
                contextoTransaction.Rollback();
                contextoTransaction.Dispose();
            }
        }

        private static void CargarDatosIniciales(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserPermissionSemilla());
        }
    }
}