using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using ExamFinalCibertec.Model;

namespace ExamFinalCibertec.AccesoDatos
{
    public class WebContextDb : DbContext
    {
        public WebContextDb() : base("WebDeveloperConnectionString")
        {
            //Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        public virtual DbSet<Autor> Autor { get; set; }

        public virtual DbSet<Libro> Libro { get; set; }


        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        //    modelBuilder.Entity<Autor>()
        //        .HasMany(e => e.Libro)
        //        .WithRequired(e => e.Autor)
        //        .WillCascadeOnDelete(false);            
        //}
    }
}
