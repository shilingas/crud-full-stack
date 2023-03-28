using crudd_backend.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace crudd_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhoneController : ControllerBase
    {
        public static List<PhoneModel> Phones = new List<PhoneModel>{ new PhoneModel(1, "Samsung", "S23", 2022, 1100),
        new PhoneModel(2, "Apple", "iPhone 14", 2022, 1300),
        new PhoneModel(3, "Google", "Pixel 7", 2022, 700),
        new PhoneModel(4, "Xiaomi", "MI 13", 2022, 800),
        new PhoneModel(5, "Apple", "iPhone 13", 2021, 650),
        new PhoneModel(6, "OnePlus", "11", 2022, 700),
    };
        [HttpGet]
        [EnableCors("corsapp")]
        public IActionResult GetPhones()
        {
            if (Phones.Count > 0)
                return Ok(Phones);
            return BadRequest("empty");
        }
        [HttpGet("{id}")]
        [EnableCors("corsapp")]
        public ActionResult<PhoneModel> GetCertainPhoneById(int id)
        {
            PhoneModel? currModel = Phones.Find(curr => curr.Id == id);
            if (currModel is not null)
                return currModel;
            return Phones.FirstOrDefault();
        }
        [HttpDelete]
        [EnableCors("corsapp")]
        public int RemovePhone(int id)
        {
            PhoneModel? model = Phones.Find(item => item.Id == id);
            Phones.Remove(model);
            if (model != null)
                return Phones.Count();
            return 0;
        }
    }
}

