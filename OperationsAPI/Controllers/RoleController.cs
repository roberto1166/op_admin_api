using System;
using AutoMapper;
using Contracts;
using Entities.DataTransferObjects.Role;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;
using Entities.Models;

namespace OperationsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private IRepositoryWrapper _repository;
        private IMapper _mapper;
        public RoleController(IRepositoryWrapper repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        // GET: api/values
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var roles = await _repository.Role.FindAll();
                var rolesMap = _mapper.Map<IEnumerable<RoleDto>>(roles);
                return Ok(rolesMap);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error: " + ex.ToString());
            }
        }

        // GET api/values/5
        [HttpGet("{id}", Name = "GetRole")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var role = await _repository.Role.FindByCondition(x => x.Id == id);
                if (role == null)
                {
                    return NotFound();
                }
                else
                {
                    var roleMap = _mapper.Map<RoleDto>(role.FirstOrDefault());
                    return Ok(roleMap);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error: " + ex.ToString());
            }
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] RoleCreateDto newRole)
        {
            try
            {
                if (newRole == null)
                {
                    return BadRequest("Role object is null");
                }

                var newRoleMap = _mapper.Map<Role>(newRole);
                _repository.Role.Create(newRoleMap);
                await _repository.Save();
                var createdRole = _mapper.Map<RoleDto>(newRoleMap);
                return CreatedAtRoute("GetRole", new { id = createdRole.Id }, createdRole);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error: " + ex.ToString());
            }
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] RoleUpdateDto roleUpdated)
        {
            try
            {
                if (roleUpdated is null)
                {
                    return BadRequest("Role object is null");
                }
                var role = await _repository.Role.FindByCondition(x => x.Id == id);
                if (role == null)
                {
                    return NotFound();
                }
                _mapper.Map(roleUpdated, role.First());
                _repository.Role.Update(role.First());
                await _repository.Save();
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error: " + ex.ToString());
            }
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var role = await _repository.Role.FindByCondition(x => x.Id == id);
                if (role == null)
                {
                    return NotFound();
                }
                role.First().Active = 0;
                _repository.Role.Update(role.First());
                await _repository.Save();
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error: " + ex.ToString());
            }

        }
    }
}

