using ASAP.API.Data.Entities;
using ASAP.API.Data.IRepos;
using ASAP.API.Extensions;
using ASAP.API.Filters;
using ASAP.API.IServices;
using ASAP.API.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ASAP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {

        private readonly IConverter<Person, PersonVM> _converter;
        private readonly IPersonRepos _person;
        public PeopleController(IConverter<Person, PersonVM> converter, 
            IPersonRepos person)
        {
            _converter = converter;
            _person = person;
        }

        [HttpGet("get-all")]
        public async Task<ActionResult<IEnumerable<PersonVM>>> Get([FromQuery] BaseFilter filter)
        {
            var list = await _person.GetPeopleAddresses().Filter(filter).ToListAsync();
            var result = (from item in list.AsParallel() select _converter.Convert(item));
            return Ok(result);
        }

        // GET api/<PeopleController>/5
        [HttpGet("get/{id}")]
        public async Task<ActionResult<PersonVM>> Get(int id)
        {
            return Ok(_converter.Convert(await _person.GetPersonAddresses(id)));
        }

        // POST api/<PeopleController>6
        [HttpPost("add")]
        public async Task<ActionResult<PersonVM>> Post([FromForm] PersonVM person)
        {
            if (person.file!=null) 
            {
                person.ImageUrl = await person.file.SaveImage("People");
            }
            Person dbPerson = _converter.Convert(person);
            await _person.AddAsync(dbPerson);
            return Ok(_converter.Convert(dbPerson));
        }

        // PUT api/<PeopleController>/5
        [HttpPut("update/{id}")]
        public async Task<ActionResult<PersonVM>> Put(int id, [FromForm] PersonVM person)
        {
            if (id != person.Id) { return BadRequest("Something Went Wrong"); }
            if (person.file != null)
            {
                person.ImageUrl = await person.file.SaveImage("People");
            }
            Person dbPerson = _converter.Convert(person);
            return _converter.Convert(await _person.UpdateAsync(dbPerson));

        }

        // DELETE api/<PeopleController>/5
        [HttpDelete("delete/{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _person.DeleteAsync(id);
            return Ok();
        }
    }
}
