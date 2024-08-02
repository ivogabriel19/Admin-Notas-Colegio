using Microsoft.EntityFrameworkCore;
using Colegio.Models;

namespace Colegio.Data
{
    public class ColegioContext : DbContext
    {
        public ColegioContext(DbContextOptions options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<CursoMateria>().HasKey(cm => new {cm.CursoId, cm.MateriaId});

            modelBuilder.Entity<CursoMateria>().HasOne(cm => cm.Curso)
                                                .WithMany(c => c.CursoMaterias)
                                                .HasForeignKey(cm => cm.CursoId);

            modelBuilder.Entity<CursoMateria>().HasOne(cm => cm.Materia)
                                                .WithMany(m => m.CursosMateria)
                                                .HasForeignKey(cm => cm.MateriaId);
        }

        public DbSet<Persona> Personas { get; set; }
        public DbSet<Administrativo> Administrativos { get; set; }
        public DbSet<Docente> Docentes { get; set; }
        public DbSet<Alumno> Alumnos { get; set; }
        public DbSet<Curso> Cursos { get; set; }
        public DbSet<CursoMateria> ClientesVehiculos { get; set; }
        public DbSet<Materia> Materias { get; set; }
        public DbSet<Evaluacion> Evaluaciones { get; set; }
        public DbSet<Examen> Examenes { get; set; }
        public DbSet<Tarea> Tareas { get; set; }

}
}
