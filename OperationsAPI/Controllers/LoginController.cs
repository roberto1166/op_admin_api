using System;
using AutoMapper;
using Contracts;
using Entities.DataTransferObjects.Log;
using Entities.DataTransferObjects.Login;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Core.Types;
using OperationsAPI.Helpers;

namespace OperationsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
	{
        private IRepositoryWrapper _repository;
        private IMapper _mapper;
        public LoginController(IRepositoryWrapper repository, IMapper mapper)
		{
            _repository = repository;
            _mapper = mapper;
		}

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] LoginDto user)
        {
            try
            {
                if (user == null)
                {
                    return BadRequest("User object is null");
                }
                var userData = await _repository.User.FindByCondition(x => x.Email == user.Email);
                if (userData.FirstOrDefault() == null)
                {
                    return BadRequest("Incorrect data");
                }
                var hashing = new HashingManager();
                var isValid = hashing.Verify(user.Password, userData.FirstOrDefault().Password);
                if (isValid)
                {
                    return Ok();
                }
                return BadRequest("Incorrect data");

            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error: " + ex.ToString());
            }
        }
    }
}

