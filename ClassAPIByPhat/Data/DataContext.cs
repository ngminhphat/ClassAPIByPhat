using ClassAPIByPhatByPhat.Models;
using Microsoft.EntityFrameworkCore;
using ClassAPIByPhatByPhat.Models;

namespace ClassAPIByPhatByPhat.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Student> Students { get; set; }
        public DbSet<Courses> Courses { get; set; }
        public DbSet<Models.ClassAPIByPhatByPhat> ClassAPIByPhatByPhat { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Models.ClassAPIByPhatByPhat>().HasKey(h => new { h.StudentId, h.CoursesId });
            builder.Entity<Models.ClassAPIByPhatByPhat>().HasOne(h => h.Courses).WithMany(h => h.ClassAPIByPhatByPhat);
            builder.Entity<Models.ClassAPIByPhatByPhat>().HasOne(h => h.Student).WithMany(h => h.ClassAPIByPhatByPhat);

            new DbInitializer(builder).Seed();
        }

        public class DbInitializer
        {
            private readonly ModelBuilder _builder;
            public DbInitializer(ModelBuilder builder)
            {
                this._builder = builder;
            }

            public void Seed()
            {
                _builder.Entity<Student>(s =>
                {
                    s.HasData(new Student
                    {
                        StudentId = new Guid("e2397972-8743-431a-9482-60292f08320e"),
                        Name = "Minh Phat"
                    });
                    s.HasData(new Student
                    {
                        StudentId = new Guid("4e79044a-988d-4488-97b7-3e474e4340d2"),
                        Name = "Le Minh Teo"
                    });
                });
                _builder.Entity<Courses>(c =>
                {
                    c.HasData(new Courses
                    {
                        CourseId = new Guid("9250d994-2558-4573-8465-417248667051"),
                        CourseName = "OOP",
                        Description = "Lap Trinh Huong Doi Tuong"
                    }); ;
                    c.HasData(new Courses
                    {
                        CourseId = new Guid("88738493-3a85-4443-8f6a-313453432192"),
                        CourseName = "Lap Trinh Web",
                        Description = "tach tach",
                    });
                });
                _builder.Entity<Models.ClassAPIByPhatByPhat>(sc =>
                {
                    sc.HasData(new Models.ClassAPIByPhatByPhat
                    {
                        StudentId = new Guid("e2397972-8743-431a-9482-60292f08320e"),
                        CoursesId = new Guid("88738493-3a85-4443-8f6a-313453432192")
                    });
                    sc.HasData(new Models.ClassAPIByPhatByPhat
                    {
                        StudentId = new Guid("4e79044a-988d-4488-97b7-3e474e4340d2"),
                        CoursesId = new Guid("9250d994-2558-4573-8465-417248667051")
                    });
                });
            }
        }
    }
}