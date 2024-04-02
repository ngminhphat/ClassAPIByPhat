using Microsoft.EntityFrameworkCore;
using ClassAPIByPhatByPhat.Data;
using ClassAPIByPhatByPhat.Models;

namespace ClassAPIByPhatByPhat.Services
{
    public class CoursesServices:ICoursesServices
    {
        private readonly DataContext _context;
        private ICoursesServices _coursesServicesImplementation;
        public CoursesServices(DataContext context) {  _context = context; }

        #region Courses

        public async Task<List<Courses>> GetAllCourses()
        {
            try
            {
                return await _context.Courses.ToListAsync();
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<Courses> GetIdCourses(Guid id, bool includeCourses)
        {
            try
            {
                if (includeCourses)
                {
                    return await _context.Courses.Include(c => c.ClassAPIByPhatByPhat).FirstOrDefaultAsync(i => i.CourseId == id);
                }

                return await _context.Courses.FindAsync(id);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<Courses> AddCourses(Courses courses)
        {
            try
            {
                await _context.Courses.AddAsync(courses);
                await _context.SaveChangesAsync();
                return await _context.Courses.FindAsync(courses.CourseId);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<Courses> UpdateCourses(Courses courses)
        {
            try
            {
                _context.Entry(courses).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return courses;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<(bool, string)> DeleteCourses(Courses courses)
        {
            try
            {
                var dbCourses = await _context.Courses.FindAsync(courses.CourseId);
                if (dbCourses == null)
                {
                    return (false, "Not Found");
                }

                _context.Courses.Remove(courses);
                return (true, "Success");
            }
            catch (Exception e)
            {
                return (false, "Failed");
            }
        }



        #endregion

        #region Student
        public Task<List<Student>> getAllStudent()
        {
            return _coursesServicesImplementation.getAllStudent();
        }
        public async Task<List<Student>> GetAllStudent()
        {
            try
            {
                return await _context.Students.ToListAsync();
            }
            catch (Exception e)
            {
                return null;
            }
        }
        public async Task<Student> GetIdStudent(Guid id, bool includeCourses)
        {
            try
            {
                if (includeCourses)
                {
                    return await _context.Students.Include(c => c.ClassAPIByPhatByPhat).FirstOrDefaultAsync(i => i.StudentId== id);
                }

                return await _context.Students.FindAsync(id);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<Student> AddStudent(Student student)
        {
            try
            {
                await _context.Students.AddAsync(student);
                await _context.SaveChangesAsync();
                return await _context.Students.FindAsync(student.StudentId);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<Student> UpdateStudent(Student student)
        {
            try
            {
                _context.Entry(student).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return student;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<(bool, string)> DeleteStudent(Student student)
        {
            try
            {
                var dbStudent = await _context.Students.FindAsync(student);
                if (dbStudent == null)
                {
                    return (false, "Courses could not be found");
                }

                _context.Students.Remove(student);
                await _context.SaveChangesAsync();
                return (true, "Amzing good job you");
            }
            catch (Exception e)
            {
                return (false, e.Message);
            }
        }

        #endregion

        #region StudentCourese

        public async Task<List<Models.ClassAPIByPhatByPhat>> GetAllSCourses()
        {
            try
            {
                return await _context.ClassAPIByPhatByPhat.ToListAsync();
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<Models.ClassAPIByPhatByPhat> GetIdSCourses(Guid id)
        {
            try
            {
                return await _context.ClassAPIByPhatByPhat.FindAsync(id);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<Models.ClassAPIByPhatByPhat> AddSCourses(Models.ClassAPIByPhatByPhat sc)
        {
            try
            {
                await _context.ClassAPIByPhatByPhat.AddAsync(sc);
                await _context.SaveChangesAsync();

                return await _context.ClassAPIByPhatByPhat.FindAsync(sc.CoursesId);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<Models.ClassAPIByPhatByPhat> UpdateSCourses(Models.ClassAPIByPhatByPhat sc)
        {
            try
            {
                _context.Entry(sc).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return sc;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<(bool, string)> DeleteSCourses(Models.ClassAPIByPhatByPhat sc)
        {
            try
            {
                var dbSC = await _context.ClassAPIByPhatByPhat.FindAsync(sc.CoursesId);
                if (dbSC == null)
                {
                    return (false, "Courses could not be found");
                }
                _context.ClassAPIByPhatByPhat.Remove(sc);
                await _context.SaveChangesAsync();
                return (true, "Amazing good job you");
            }
            catch (Exception e)
            {
                return (false, e.Message);
            }
        }
        #endregion
    }
}
