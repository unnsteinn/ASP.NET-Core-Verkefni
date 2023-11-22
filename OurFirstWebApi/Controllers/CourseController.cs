using Microsoft.AspNetCore.Mvc;
using OurFirstWebApi.Data.Interface;
using OurFirstWebApi.Models;

namespace OurFirstWebApi.Controllers
{

    [Route("api/courses")]
    [Controller]
    public class CourseController : ControllerBase
    {
        private readonly IRepository _repository;

        public CourseController(IRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Course>>> GetAllCourses()
        {
            try
            {
                var courses = await _repository.GetAllCoursesAsync();
                return Ok(courses);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Course>> GetCourseById(int id)
        {
            try
            {
                var course = await _repository.GetCourseByIdAsync(id);

                if (course == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(course);
                }
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpPost]
        public IActionResult CreateCourse([FromBody] Course course)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //_repository.CreateCourse(course);
                    return CreatedAtAction(nameof(GetCourseById), new { id = course.Id }, course);
                }
                else { return BadRequest(); }
            }
            catch (Exception)
            {

                return StatusCode(500);
            }
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateCourse(int id, [FromBody] Course course)
        {
            try
            {
                var updatedCourse = await _repository.UpdateCourseAsync(id, course);

                if (updatedCourse == null)
                {
                    return NotFound("Course not found");
                }
                else
                {
                    return CreatedAtAction(nameof(GetCourseById), new { id = updatedCourse.Id }, updatedCourse);
                }
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult<Course>> DeleteCourse(int id)
        {
            try
            {
                bool deleteSuccessful = await _repository.DeleteCourseAsync(id);
                if (!deleteSuccessful)
                {
                    return NotFound();
                }
                else
                {
                    return NoContent();
                }
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

    }
}
