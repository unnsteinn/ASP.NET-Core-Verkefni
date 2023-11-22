
using Microsoft.EntityFrameworkCore;
using OurFirstWebApi.Models;
using Verkefni_Entity_framework.Models;

namespace OurFirstWebApi.Data.Repository
{
    public class SchoolDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Mark> Marks { get; set; }

        public DbSet<Group> Groups { get; set; }


        public SchoolDbContext(DbContextOptions<SchoolDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=NewSchoolDb");
        }


    }
}