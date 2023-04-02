using crudd_backend.Contexts;
using crudd_backend.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;
using Microsoft.Extensions.Hosting;

namespace crudd_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly PersonContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;


        public PersonController(PersonContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _hostEnvironment = hostEnvironment;
        }
        [HttpPost]
        [EnableCors("corsapp")]
        public async Task<IActionResult> Post([FromForm] Person person)
        {
            person.ImageName = await SaveImage(person.ImageFile);
            _context.Persons.Add(person);
            await _context.SaveChangesAsync();
            return Ok(person);
        }
        [HttpGet]
        [EnableCors("corsapp")]
        public async Task<Person[]> GetAll()
        {
            var data = await _context.Persons.ToArrayAsync();
            return data;
        }

        [NonAction]
        public async Task<string> SaveImage(IFormFile imageFile)
        {
            string imageName = new String(Path.GetFileNameWithoutExtension(imageFile.FileName).Take(10).ToArray()).Replace(' ', '-');
            imageName = imageName + DateTime.Now.ToString("yymmssfff") + Path.GetExtension(imageFile.FileName);
            var imagePath = Path.Combine(_hostEnvironment.ContentRootPath, "Images", imageName);
            using (var fileStream = new FileStream(imagePath, FileMode.Create))
            {
                await imageFile.CopyToAsync(fileStream);
            }
            return imageName;
        }
    }
}
