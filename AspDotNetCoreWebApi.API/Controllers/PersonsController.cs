using AspDotNetCoreWebApi.API.DTO;
using AspDotNetCoreWebApi.Core.Entity;
using AspDotNetCoreWebApi.Core.Service;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AspDotNetCoreWebApi.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        private readonly IService<Person> _personService;
        private readonly IMapper _mapper;

        public PersonsController(IService<Person> personService, IMapper mapper)
        {
            _personService = personService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var persons = await _personService.GetAllAsync();

            return Ok(_mapper.Map<IEnumerable<PersonDto>>(persons));
        }

        [HttpPost]
        public async Task<IActionResult> Save(PersonDto personDto)
        {
            var newPerson = await _personService.AddAsync(_mapper.Map<Person>(personDto));

            return Created(string.Empty, _mapper.Map<PersonDto>(newPerson));
        }
    }
}
