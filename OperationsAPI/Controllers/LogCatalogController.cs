using System;
using AutoMapper;
using Contracts;
using Entities.DataTransferObjects.LogCatalog;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace OperationsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogCatalogController : ControllerBase
    {
        private IRepositoryWrapper _repository;
        private IMapper _mapper;
        public LogCatalogController(IRepositoryWrapper repository, IMapper mapper)
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
                var logsCatalog = await _repository.LogCatalog.FindAll();
                var logsCatalogMap = _mapper.Map<IEnumerable<LogCatalogDto>>(logsCatalog);
                return Ok(logsCatalogMap);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error: " + ex.ToString());
            }
        }

        // GET api/values/5
        [HttpGet("{id}", Name = "GetLogCatalog")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var logCatalog = await _repository.LogCatalog.FindByCondition(x => x.Id == id);
                if (logCatalog == null)
                {
                    return NotFound();
                }
                else
                {
                    var logMap = _mapper.Map<LogCatalogDto>(logCatalog.FirstOrDefault());
                    return Ok(logMap);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error: " + ex.ToString());
            }
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] LogCatalogCreateDto newLogCatalog)
        {
            try
            {
                if (newLogCatalog == null)
                {
                    return BadRequest("LogCatalog object is null");
                }

                var newLogCatalogMap = _mapper.Map<LogCatalog>(newLogCatalog);
                _repository.LogCatalog.Create(newLogCatalogMap);
                await _repository.Save();
                var createdLogCatalog = _mapper.Map<LogCatalogDto>(newLogCatalogMap);
                return CreatedAtRoute("GetLogCatalog", new { id = createdLogCatalog.Id }, createdLogCatalog);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error: " + ex.ToString());
            }
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] LogCatalogUpdateDto logCatalogUpdated)
        {
            try
            {
                if (logCatalogUpdated is null)
                {
                    return BadRequest("LogCatalog object is null");
                }
                var logCatalog = await _repository.LogCatalog.FindByCondition(x => x.Id == id);
                if (logCatalog == null)
                {
                    return NotFound();
                }
                _mapper.Map(logCatalogUpdated, logCatalog.First());
                _repository.LogCatalog.Update(logCatalog.First());
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
                var logCatalog = await _repository.LogCatalog.FindByCondition(x => x.Id == id);
                if (logCatalog == null)
                {
                    return NotFound();
                }
                logCatalog.First().Active = 0;
                _repository.LogCatalog.Update(logCatalog.First());
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

