using Microsoft.AspNetCore.Mvc;
using OurFirstWebApi.Data.Interface;
using Verkefni_Entity_framework.Models;

namespace OurFirstWebApi.Controllers
{
    [Route("api/groups")]
    [ApiController]
    public class GroupsController : ControllerBase
    {
        private readonly IRepository _repository;

        public GroupsController(IRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Group>>> GetAllGroups()
        {
            try
            {
                var groups = await _repository.GetAllGroupsAsync();
                return Ok(groups);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Group>> GetGroupById(int id)
        {
            try
            {
                var group = await _repository.GetGroupByIdAsync(id);

                if (group == null)
                {
                    return NotFound();
                }

                return Ok(group);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpPost]
        public async Task<ActionResult<Group>> CreateGroup([FromBody] Group group)
        {
            try
            {
                if (group == null)
                {
                    return BadRequest();
                }

                await _repository.CreateGroupAsync(group);

                return CreatedAtAction(nameof(GetGroupById), new { id = group.Id }, group);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Group>> UpdateGroup(int id, [FromBody] Group group)
        {
            try
            {
                var existingGroup = await _repository.GetGroupByIdAsync(id);

                if (existingGroup == null)
                {
                    return NotFound();
                }

                existingGroup.Name = group.Name;

                await _repository.UpdateGroupAsync(id, existingGroup);

                return Ok(existingGroup);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Group>> DeleteGroup(int id)
        {
            try
            {
                var groupToRemove = await _repository.GetGroupByIdAsync(id);

                if (groupToRemove == null)
                {
                    return NotFound();
                }

                await _repository.DeleteGroupAsync(id);

                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
    }
}
