using Microsoft.AspNetCore.Mvc;
using OurFirstWebApi.Data.Interface;
using Verkefni_Entity_framework.Models;

namespace YourNamespace.Controllers
{
    [Route("api/teachers")]
    [Controller]
    public class TeacherController : ControllerBase
    {
        private readonly List<Teacher> _teachers = new List<Teacher>();

        private readonly IRepository _repository;

        public TeacherController(IRepository repository)
        {
            _repository = repository;
        }

        private readonly List<Subject> _subjects = new List<Subject>();

        [HttpGet]
        public async Task<ActionResult<List<Teacher>>> GetAllTeachers()
        {
            try
            {
                var teachers = await _repository.GetAllTeachersAsync();
                return Ok(teachers);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Teacher>> GetTeacherById(int id)
        {
            try
            {

                var teacher = await _repository.GetTeacherByIdAsync(id);


                if (teacher == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(teacher);
                }
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateTeacher([FromBody] Teacher teacher)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    teacher.Id = teacher.Id;
                    _teachers.Add(teacher);
                    await _repository.CreateTeacherAsync(teacher);
                    return CreatedAtAction(nameof(GetTeacherById), new { id = teacher.Id }, teacher);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTeacher(int id, [FromBody] Teacher teacher)
        {
            try
            {
                var existingTeacher = _teachers.Find(t => t.Id == id);

                if (existingTeacher == null)
                {
                    return NotFound("Teacher not found");
                }

                existingTeacher.FirstName = teacher.FirstName;
                existingTeacher.LastName = teacher.LastName;
                existingTeacher.Subjects = teacher.Subjects;


                await _repository.UpdateTeacherAsync(id, existingTeacher);

                return Ok(existingTeacher);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Teacher>> DeleteTeacher(int id)
        {
            try
            {

                var teacherToRemove = await _repository.GetTeacherByIdAsync(id);

                if (teacherToRemove == null)
                {
                    return NotFound();
                }

                _teachers.Remove(teacherToRemove);



                await _repository.DeleteTeacherAsync(id);

                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
    }
}