using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OperationsAPI.Controllers
{
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private IRepositoryWrapper _repository;
        public AccountController(IRepositoryWrapper repository)
        {
            _repository = repository;
        }
        // GET: api/values
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var accounts = await _repository.Account.FindAll();
            return Ok(accounts);
        }

        // GET api/values/5
        [HttpGet("{id}", Name = "GetAccount")]
        public async Task<IActionResult> Get(int id)
        {
            var account = await _repository.Account.FindByCondition(x=>x.Id == id);
            return Ok(account);
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Account newAccount)
        {
            _repository.Account.Create(newAccount);
            await _repository.Save();
            return CreatedAtRoute("GetAccount", new { id = newAccount.Id }, newAccount);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

