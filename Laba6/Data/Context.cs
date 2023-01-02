using Microsoft.EntityFrameworkCore;
using Laba6.Models;

namespace Laba6.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        { }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Discipline> Disciplines { get; set; }
        public DbSet<DisciplineList> DisciplineLists { get; set; }
        public DbSet<Faculty> Faculties { get; set; }
        public DbSet<Specialization> Specializations { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
    }
}
