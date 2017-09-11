using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Tano.EntityFramework.Context
{   
    public class ContextDb<T> : DbContext where T : class
    {   
        public ContextDb() : base("ContextDB") { }
        public DbSet<T> Context { get; set; }
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            //modelBuilder.Entity<T>();
            //modelBuilder.Entity<T>().MapToStoredProcedures();
        }

    }

}
