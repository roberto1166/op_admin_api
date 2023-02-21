using System;
using AutoMapper;
using Contracts;
using Entities.DataTransferObjects.Log;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;
using Entities.Models;

namespace OperationsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogController : ControllerBase
    {
        private IRepositoryWrapper _repository;
        private IMapper _mapper;
        public LogController(IRepositoryWrapper repository, IMapper mapper)
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
                var logs = await _repository.Log.FindAll();
                var logsMap = _mapper.Map<IEnumerable<LogDto>>(logs);
                return Ok(logsMap);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error: " + ex.ToString());
            }
        }

        // GET api/values/5
        [HttpGet("{id}", Name = "GetLog")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var log = await _repository.Log.FindByCondition(x => x.Id == id);
                if (log == null)
                {
                    return NotFound();
                }
                else
                {
                    var logMap = _mapper.Map<LogDto>(log.FirstOrDefault());
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
        public async Task<IActionResult> Post([FromBody] LogCreateDto newLog)
        {
            try
            {
                if (newLog == null)
                {
                    return BadRequest("Log object is null");
                }

                var newLogMap = _mapper.Map<Log>(newLog);
                _repository.Log.Create(newLogMap);
                await _repository.Save();
                var createdLog = _mapper.Map<LogDto>(newLogMap);
                return CreatedAtRoute("GetLog", new { id = createdLog.Id }, createdLog);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error: " + ex.ToString());
            }
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] LogUpdateDto logUpdated)
        {
            try
            {
                if (logUpdated is null)
                {
                    return BadRequest("Log object is null");
                }
                var log = await _repository.Log.FindByCondition(x => x.Id == id);
                if (log == null)
                {
                    return NotFound();
                }
                _mapper.Map(logUpdated, log.First());
                _repository.Log.Update(log.First());
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

