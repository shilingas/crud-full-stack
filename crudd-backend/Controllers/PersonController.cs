using crudd_backend.Contexts;
using crudd_backend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        public async Task<IActionResult> Post([FromBody] Person person)
        {
            _context.Add(person);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpGet]
        public async Task<Person[]> GetPersons()
        {
            var currentData = await _context.Persons.ToArrayAsync();
            await _context.SaveChangesAsync();
            return currentData;
        }
    }
}
