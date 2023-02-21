using AutoMapper;
using Contracts;
using Entities.DataTransferObjects.Client;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;

namespace OperationsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private IRepositoryWrapper _repository;
        private IMapper _mapper;
        public ClientController(IRepositoryWrapper repository, IMapper mapper)
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
                var clients = await _repository.Client.FindAll();
                var clientsMap = _mapper.Map<IEnumerable<ClientDto>>(clients);
                return Ok(clientsMap);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error: " + ex.ToString());
            }
        }

        // GET api/values/5
        [HttpGet("{id}", Name = "GetClient")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var client = await _repository.Client.FindByCondition(x => x.Id == id);
                if (client == null)
                {
                    return NotFound();
                }
                else
                {
                    var clientMap = _mapper.Map<ClientDto>(client.FirstOrDefault());
                    return Ok(clientMap);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error: " + ex.ToString());
            }
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ClientCreateDto newClient)
        {
            try
            {
                if (newClient == null)
                {
                    return BadRequest("Client object is null");
                }

                var newClientMap = _mapper.Map<Client>(newClient);
                _repository.Client.Create(newClientMap);
                await _repository.Save();
                var createdClient = _mapper.Map<ClientDto>(newClientMap);
                return CreatedAtRoute("GetClient", new { id = createdClient.Id }, createdClient);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error: " + ex.ToString());
            }
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] ClientUpdateDto clientUpdated)
        {
            try
            {
                if (clientUpdated is null)
                {
                    return BadRequest("Client object is null");
                }
                var client = await _repository.Client.FindByCondition(x => x.Id == id);
                if (client == null)
                {
                    return NotFound();
                }
                _mapper.Map(clientUpdated, client.First());
                _repository.Client.Update(client.First());
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
                var client = await _repository.Client.FindByCondition(x => x.Id == id);
                if (client == null)
                {
                    return NotFound();
                }
                client.First().Active = 0;
                _repository.Client.Update(client.First());
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
