using UserPermission.core.entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace UserPermission.infrastructure.data
{
    public class PermissionContext : DbContext
    {
        private IDbContextTransaction transactionContext;

        public PermissionContext(DbContextOptions<PermissionContext> options) : base(options) { }

        public DbSet<PermissionEntity> UserPermissionEntity { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            InitialData(modelBuilder);
        }

        public virtual void BeginTransaction()
        {
            transactionContext = Database.BeginTransaction();
        }

        public virtual void CommitTransaction()
        {
            try
            {
                SaveChanges();
                transactionContext.Commit();
            }
            finally
            {
                transactionContext.Dispose();
            }
        }

        public virtual void RollbackTransaction()
        {
            if (transactionContext != null)
            {
                transactionContext.Rollback();
                transactionContext.Dispose();
            }
        }

        private static void InitialData(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PermissionTypeSeed());
            modelBuilder.ApplyConfiguration(new EmployeeSeed());
        }
    }
}