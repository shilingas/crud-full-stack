using crudd_backend.Contexts;
using crudd_backend.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;

namespace crudd_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly PersonContext _context;

        public PersonController(PersonContext context)
        {
            _context = context;
        }
        [HttpPost]
        [EnableCors("corsapp")]
        public async Task<IActionResult> Post([FromBody] Person person)
        {
            _context.Add(person);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpGet]
        [EnableCors("corsapp")]
        public async Task<Person[]> GetPersons()
        {
            var currentData = await _context.Persons.ToArrayAsync();
            await _context.SaveChangesAsync();
            return currentData;
        }
        [HttpDelete("{id}")]
        [EnableCors("corsapp")]
        public async Task<IActionResult> RemovePerson(int id)
        {
            var findPerson = await _context.Persons.FindAsync(id);
            if (findPerson != null)
            {
                _context.Persons.Remove(findPerson);
                await _context.SaveChangesAsync();
                return Ok("removed");
            }
            return Ok("didn't find person");
        }
        [HttpPut("{id}")]
        [EnableCors("corsapp")]
        public async Task<IActionResult> UpdatePerson([FromBody] Person person, int id)
        {
            var specPerson = await _context.Persons.FindAsync(id);
            if (specPerson != null)
            {
                specPerson.Name = person.Name;
                specPerson.Surname = person.Surname;
                await _context.SaveChangesAsync();
                return Ok("updated");
            }
            return Ok("something is wrong");
        }
    }
}
