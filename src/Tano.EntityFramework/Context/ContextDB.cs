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
            //// Utilizado para desabilitar a pluralizacao dos nomes das tabelas
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            //modelBuilder.Entity<T>();
            //modelBuilder.Entity<T>().MapToStoredProcedures();

            //// Desabilitar a exclus�o em cascata de objetos.
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();


            //modelBuilder.Configurations.Add(new ParceiroMap());
        }

    }

}
