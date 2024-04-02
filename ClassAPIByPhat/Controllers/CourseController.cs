﻿using Microsoft.AspNetCore.Mvc;
using ClassAPIByPhatByPhat.Models;
using ClassAPIByPhatByPhat.Services;

namespace REST_API_TEMPLATE.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CourseController : ControllerBase
    {
        private readonly ICoursesServices _coursesService;

        public CourseController(ICoursesServices coursesService)
        {
            _coursesService = coursesService;
        }

        [HttpGet]
        public async Task<IActionResult> GetCourses()
        {
            var Courses = await _coursesService.GetAllCourses();

            if (Courses == null)
            {
                return StatusCode(StatusCodes.Status204NoContent, "No Courses in database");
            }

            return StatusCode(StatusCodes.Status200OK, Courses);
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetCourses(Guid id, bool includeCourses = false)
        {
            Courses courses = await _coursesService.GetIdCourses(id, includeCourses);

            if (courses == null)
            {
                return StatusCode(StatusCodes.Status204NoContent, $"No Course found for id: {id}");
            }

            return StatusCode(StatusCodes.Status200OK, courses);
        }

        [HttpPost]
        public async Task<ActionResult<Courses>> AddCourses(Courses courses)
        {
            var dbCourses = await _coursesService.AddCourses(courses);

            if (dbCourses == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"{courses.CourseName} could not be added.");
            }

            return CreatedAtAction("GetCourses", new { id = courses.CourseId }, courses);
        }

        [HttpPut("id")]
        public async Task<IActionResult> UpdateCourses(Guid id, Courses courses)
        {
            if (id != courses.CourseId)
            {
                return BadRequest();
            }

            Courses dbCourses = await _coursesService.UpdateCourses(courses);

            if (dbCourses == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"{courses.CourseName} could not be updated");
            }

            return NoContent();
        }

        [HttpDelete("id")]
        public async Task<IActionResult> DeleteCourse(Guid id)
        {
            var courses = await _coursesService.GetIdCourses(id, false);
            (bool status, string message) = await _coursesService.DeleteCourses(courses);

            if (status == false)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, message);
            }

            return StatusCode(StatusCodes.Status200OK, courses);
        }
    }
}