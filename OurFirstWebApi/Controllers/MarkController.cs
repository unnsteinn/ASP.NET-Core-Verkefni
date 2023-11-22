using Microsoft.AspNetCore.Mvc;
using OurFirstWebApi.Data.Interface;
using Verkefni_Entity_framework.Models;

namespace OurFirstWebApi.Controllers
{
    [Route("api/marks")]
    [ApiController]
    public class MarksController : ControllerBase
    {
        private readonly IRepository _repository;

        public MarksController(IRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Mark>>> GetAllMarks()
        {
            try
            {
                var marks = await _repository.GetAllMarksAsync();
                return Ok(marks);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Mark>> GetMarkById(int id)
        {
            try
            {
                var mark = await _repository.GetMarkByIdAsync(id);

                if (mark == null)
                {
                    return NotFound();
                }

                return Ok(mark);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpPost]
        public async Task<ActionResult<Mark>> CreateMark([FromBody] Mark mark)
        {
            try
            {
                if (mark == null)
                {
                    return BadRequest();
                }

                await _repository.CreateMarkAsync(mark);

                return CreatedAtAction(nameof(GetMarkById), new { id = mark.Id }, mark);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Mark>> UpdateMark(int id, [FromBody] Mark mark)
        {
            try
            {
                var existingMark = await _repository.GetMarkByIdAsync(id);

                if (existingMark == null)
                {
                    return NotFound();
                }

                existingMark.StudentId = mark.StudentId;
                existingMark.SubjectId = mark.SubjectId;
                existingMark.Date = mark.Date;
                existingMark.Grade = mark.Grade;

                await _repository.UpdateMarkAsync(id, existingMark);

                return Ok(existingMark);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Mark>> DeleteMark(int id)
        {
            try
            {
                var markToRemove = await _repository.GetMarkByIdAsync(id);

                if (markToRemove == null)
                {
                    return NotFound();
                }

                await _repository.DeleteMarkAsync(id);

                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
    }
}
