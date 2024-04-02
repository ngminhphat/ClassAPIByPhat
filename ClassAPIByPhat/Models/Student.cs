using System.ComponentModel.DataAnnotations;

namespace ClassAPIByPhatByPhat.Models
{
    public class Student
    {
        [Key]
        public Guid? StudentId { get; set; }    
        public string? Name { get; set; }
        public List<ClassAPIByPhatByPhat>? ClassAPIByPhatByPhat { get; set;}
    }
}
