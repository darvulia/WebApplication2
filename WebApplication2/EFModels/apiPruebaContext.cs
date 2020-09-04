using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebApplication2.EFModels
{
    public partial class apiPruebaContext : DbContext
    {
        public apiPruebaContext()
        {
        }

        public apiPruebaContext(DbContextOptions<apiPruebaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Sumas> Sumas { get; set; }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                optionsBuilder.UseSqlServer("Server=localhost;Database=apiPrueba;USER ID=sa; Password=789632145;Trusted_Connection=True;");
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Sumas>(entity =>
            {
                entity.ToTable("sumas");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Resultado)
                    .HasColumnName("resultado")
                    .HasColumnType("numeric(18, 2)");

                entity.Property(e => e.Valor1)
                    .HasColumnName("valor1")
                    .HasColumnType("numeric(18, 2)");

                entity.Property(e => e.Valor2)
                    .HasColumnName("valor2")
                    .HasColumnType("numeric(18, 2)");
            });
        }

        //internal Task Sumas(Sumas suma)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
