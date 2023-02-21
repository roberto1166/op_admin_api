using System;
using AutoMapper;
using Contracts;
using Entities.DataTransferObjects.User;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;
using Entities.Models;
using OperationsAPI.Helpers;

namespace OperationsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IRepositoryWrapper _repository;
        private IMapper _mapper;
        public UserController(IRepositoryWrapper repository, IMapper mapper)
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
                var users = await _repository.User.FindAll();
                var usersMap = _mapper.Map<IEnumerable<UserDto>>(users);
                return Ok(usersMap);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error: " + ex.ToString());
            }
        }

        // GET api/values/5
        [HttpGet("{id}", Name = "GetUser")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var user = await _repository.User.FindByCondition(x => x.Id == id);
                if (user == null)
                {
                    return NotFound();
                }
                else
                {
                    var userMap = _mapper.Map<UserDto>(user.FirstOrDefault());
                    return Ok(userMap);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error: " + ex.ToString());
            }
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UserCreateDto newUser)
        {
            try
            {
                if (newUser == null)
                {
                    return BadRequest("User object is null");
                }

                var newUserMap = _mapper.Map<User>(newUser);
                var hashing = new HashingManager();
                var hash = hashing.HashToString(newUserMap.Password);
                newUserMap.Password = hash;
                _repository.User.Create(newUserMap);
                await _repository.Save();
                var createdUser = _mapper.Map<UserDto>(newUserMap);
                return CreatedAtRoute("GetUser", new { id = createdUser.Id }, createdUser);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error: " + ex.ToString());
            }
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UserUpdateDto userUpdated)
        {
            try
            {
                if (userUpdated is null)
                {
                    return BadRequest("User object is null");
                }
                var user = await _repository.User.FindByCondition(x => x.Id == id);
                if (user == null)
                {
                    return NotFound();
                }
                _mapper.Map(userUpdated, user.First());
                _repository.User.Update(user.First());
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
                var user = await _repository.User.FindByCondition(x => x.Id == id);
                if (user == null)
                {
                    return NotFound();
                }
                user.First().Active = 0;
                _repository.User.Update(user.First());
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

