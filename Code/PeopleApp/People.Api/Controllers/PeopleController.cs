using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using People.Api.Requests;
using People.Application.Interfaces;
using People.Domain.Entities;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace People.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private readonly IPersonService _personService;
        private readonly IMapper _mapper;

        public PeopleController(IPersonService personService, IMapper mapper)
        {
            _personService = personService;
            _mapper = mapper;   
        }

        // GET: api/<PeopleController>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _personService.GetAllAsync());
        }

        // GET api/<PeopleController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _personService.GetByIdAsync(id));
        }

        // POST api/<PeopleController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Person person)
        {
            return Ok(await _personService.AddAsync(person));
        }

        // PUT api/<PeopleController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Person person)
        {
            await _personService.UpdateAsync(id, person);
            return Ok();
        }

        // DELETE api/<PeopleController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _personService.RemoveAsync(id);
            return Ok();
        }

        // POST api/<PeopleController>/Create
        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] PersonRequest personRequest)
        {
            var person = _mapper.Map<Person>(personRequest);
            return Ok(await _personService.AddAsync(person));
        }
    }
}