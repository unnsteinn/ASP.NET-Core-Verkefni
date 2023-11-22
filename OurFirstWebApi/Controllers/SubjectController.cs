using Microsoft.AspNetCore.Mvc;
using OurFirstWebApi.Data.Interface;
using Verkefni_Entity_framework.Models;

namespace YourNamespace.Controllers
{
    [Route("api/subjects")]
    [Controller]
    public class SubjectController : ControllerBase
    {
        private readonly IRepository _repository;

        public SubjectController(IRepository repository)
        {
            _repository = repository;
        }
        private readonly List<Subject> _subjects = new List<Subject>();

        [HttpGet]
        public async Task<ActionResult<List<Subject>>> GetAllSubjects()
        {
            try
            {
                var subjects = await _repository.GetAllSubjectsAsync();
                return Ok(subjects);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Subject>> GetSubjectById(int id)
        {
            try
            {
                var subject = await _repository.GetSubjectByIdAsync(id);

                if (subject == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(subject);
                }
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateSubject([FromBody] Subject subject)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _repository.CreateSubjectAsync(subject);
                    return CreatedAtAction(nameof(GetSubjectById), new { id = subject.Id }, subject);
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
        public async Task<IActionResult> UpdateSubject(int id, [FromBody] Subject subject)
        {
            try
            {
                var existingSubject = await _repository.GetSubjectByIdAsync(id);

                if (existingSubject == null)
                {
                    return NotFound("Subject not found");
                }

                existingSubject.Title = subject.Title;
                existingSubject.Teachers = subject.Teachers;

                await _repository.UpdateSubjectAsync(id, existingSubject);

                return Ok(existingSubject);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Subject>> DeleteSubject(int id)
        {
            try
            {
                var subjectToDelete = await _repository.GetSubjectByIdAsync(id);

                if (subjectToDelete == null)
                {
                    return NotFound();
                }

                await _repository.DeleteSubjectAsync(id);

                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
    }
}