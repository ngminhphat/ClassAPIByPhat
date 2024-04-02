using System.ComponentModel.DataAnnotations;

namespace ClassAPIByPhatByPhat.Models
{
    public class Courses
    {
        [Key]
        public Guid? CourseId{ get; set; }
        public string? CourseName { get; set; }
        public string? Description { get; set; }
        public List<ClassAPIByPhatByPhat>? ClassAPIByPhatByPhat { get; set; }
    }
}
