using System;
using AutoMapper;
using Contracts;
using Entities.DataTransferObjects.UserAccountMember;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;
using Entities.Models;

namespace OperationsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserAccountMemberController : ControllerBase
    {
        private IRepositoryWrapper _repository;
        private IMapper _mapper;
        public UserAccountMemberController(IRepositoryWrapper repository, IMapper mapper)
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
                var userAccountMembers = await _repository.UserAccountMember.FindAll();
                var userAccountMembersMap = _mapper.Map<IEnumerable<UserAccountMemberDto>>(userAccountMembers);
                return Ok(userAccountMembersMap);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error: " + ex.ToString());
            }
        }

        // GET api/values/5
        [HttpGet("{id}", Name = "GetUserAccountMember")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var userAccountMember = await _repository.UserAccountMember.FindByCondition(x => x.Id == id);
                if (userAccountMember == null)
                {
                    return NotFound();
                }
                else
                {
                    var userAccountMemberMap = _mapper.Map<UserAccountMemberDto>(userAccountMember.FirstOrDefault());
                    return Ok(userAccountMemberMap);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error: " + ex.ToString());
            }
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UserAccountMemberCreateDto newUserAccountMember)
        {
            try
            {
                if (newUserAccountMember == null)
                {
                    return BadRequest("UserAccountMember object is null");
                }

                var newUserAccountMemberMap = _mapper.Map<UserAccountMember>(newUserAccountMember);
                _repository.UserAccountMember.Create(newUserAccountMemberMap);
                await _repository.Save();
                var createdUserAccountMember = _mapper.Map<UserAccountMemberDto>(newUserAccountMemberMap);
                return CreatedAtRoute("GetUserAccountMember", new { id = createdUserAccountMember.Id }, createdUserAccountMember);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error: " + ex.ToString());
            }
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UserAccountMemberUpdateDto userAccountMemberUpdated)
        {
            try
            {
                if (userAccountMemberUpdated is null)
                {
                    return BadRequest("UserAccountMember object is null");
                }
                var userAccountMember = await _repository.UserAccountMember.FindByCondition(x => x.Id == id);
                if (userAccountMember == null)
                {
                    return NotFound();
                }
                _mapper.Map(userAccountMemberUpdated, userAccountMember.First());
                _repository.UserAccountMember.Update(userAccountMember.First());
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
                var userAccountMember = await _repository.UserAccountMember.FindByCondition(x => x.Id == id);
                if (userAccountMember == null)
                {
                    return NotFound();
                }
                userAccountMember.First().Active = 0;
                _repository.UserAccountMember.Update(userAccountMember.First());
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

