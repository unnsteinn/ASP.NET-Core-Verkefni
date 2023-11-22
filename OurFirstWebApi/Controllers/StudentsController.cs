using Microsoft.AspNetCore.Mvc;
using OurFirstWebApi.Data.Interface;
using OurFirstWebApi.Models;
using OurFirstWebApi.Models.DTO;

namespace OurFirstWebApi.Controllers
{
    [Route("api/students")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IRepository _repository;


        public StudentsController(IRepository repository)
        {
            _repository = repository;

        }



        [HttpGet]
        public async Task<ActionResult<List<StudentDTO>>> GetAllStudentsAsync()
        {
            try
            {
                List<StudentDTO> students = await _repository.GetAllStudentsAsync();
                return Ok(students);
            }
            catch (Exception)
            {

                return StatusCode(500);
            }



        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<StudentDTO>> GetStudentById(int id)
        {
            try
            {
                StudentDTO stud = await _repository.GetStudentByIdAsync(id);

                if (stud == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(stud);
                }
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        //Create Student
        [HttpPost]
        public async Task<IActionResult> CreateStudent([FromBody] Student student)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _repository.CreateStudentAsync(student);
                    return CreatedAtAction(nameof(GetStudentById), new { id = student.Id }, student);
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }


        [HttpPut]
        [Route("{id}")]
        public async Task<ActionResult<List<StudentDTO>>> GetAllStudents()
        {
            try
            {
                var students = await _repository.GetAllStudentsAsync();
                return Ok(students);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult<Student>> DeleteStudent(int id)
        {
            try
            {
                bool deleteSuccessful = await _repository.DeleteStudentAsync(id);
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

