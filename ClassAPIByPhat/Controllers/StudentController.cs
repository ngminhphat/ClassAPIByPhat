using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ClassAPIByPhatByPhat.Models;
using ClassAPIByPhatByPhat.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace REST_API_TEMPLATE.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly ICoursesServices _coursesService;

        public StudentController(ICoursesServices coursesService)
        {
            _coursesService = coursesService;
        }

        [HttpGet]
        public async Task<IActionResult> GetStudents()
        {
            var students = await _coursesService.getAllStudent();

            if (students == null)
            {
                return StatusCode(StatusCodes.Status204NoContent, "No students in database");
            }

            return StatusCode(StatusCodes.Status200OK, students);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudent(Guid id)
        {
            Student student = await _coursesService.GetIdStudent(id, includeCourses: false);

            if (student == null)
            {
                return StatusCode(StatusCodes.Status204NoContent, $"No student found for id: {id}");
            }

            return StatusCode(StatusCodes.Status200OK, student);
        }

        [HttpPost]
        public async Task<ActionResult<Student>> AddStudent(Student student)
        {
            var dbStudent = await _coursesService.AddStudent(student);

            if (dbStudent == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Student could not be added.");
            }

            return CreatedAtAction(nameof(GetStudent), new { id = student.StudentId }, student);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStudent(Guid id, Student student)
        {
            if (id != student.StudentId)
            {
                return BadRequest();
            }

            Student dbStudent = await _coursesService.UpdateStudent(student);

            if (dbStudent == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Student could not be updated");
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(Guid id)
        {
            var student = await _coursesService.GetIdStudent(id, includeCourses: false);
            (bool status, string message) = await _coursesService.DeleteStudent(student);

            if (status == false)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, message);
            }

            return StatusCode(StatusCodes.Status200OK, student);
        }
    }
}
