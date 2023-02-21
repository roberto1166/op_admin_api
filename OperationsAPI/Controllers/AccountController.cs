using AutoMapper;
using Contracts;
using Entities.DataTransferObjects;
using Entities.DataTransferObjects.Account;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OperationsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private IRepositoryWrapper _repository;
        private IMapper _mapper;
        public AccountController(IRepositoryWrapper repository, IMapper mapper)
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
                var accounts = await _repository.Account.FindAllInclude();
                var accountsMap = _mapper.Map<IEnumerable<AccountDto>>(accounts);
                return Ok(accountsMap);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error: " + ex.ToString() );
            }
        }

        // GET api/values/5
        [HttpGet("{id}", Name = "GetAccount")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var account = await _repository.Account.FindByCondition(x => x.Id == id);
                if (account == null || account.Count() == 0)
                {
                    return NotFound();
                }
                else
                {
                    var accountMap = _mapper.Map<AccountDto>(account.FirstOrDefault());
                    return Ok(accountMap);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error: " + ex.ToString());
            }
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]AccountCreateDto newAccount)
        {
            try
            {
                if (newAccount == null)
                {
                    return BadRequest("Account object is null");
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid model object");
                }
                var newAccountMap = _mapper.Map<Account>(newAccount);
                _repository.Account.Create(newAccountMap);
                await _repository.Save();
                var createdAccount = _mapper.Map<AccountDto>(newAccountMap);
                return CreatedAtRoute("GetAccount", new { id = createdAccount.Id }, createdAccount);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error: " + ex.ToString());
            }
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] AccountUpdateDto accountUpdated)
        {
            try
            {
                if (accountUpdated is null)
                {
                    return BadRequest("Account object is null");
                }
                var account = await _repository.Account.FindByCondition(x => x.Id == id);
                if (account == null || account.Count() == 0)
                {
                    return NotFound();
                }
                _mapper.Map(accountUpdated, account.First());
                _repository.Account.Update(account.First());
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
                var account = await _repository.Account.FindByCondition(x => x.Id == id);
                if (account == null || account.Count() == 0)
                {
                    return NotFound();
                }
                account.First().Active = 0;
                _repository.Account.Update(account.First());
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

