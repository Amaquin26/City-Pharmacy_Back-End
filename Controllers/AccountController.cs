using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CityPharmacyAPI.Controllers
{
    [Route("[controller]]/[action]")]
    [ApiController]
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return Ok();
        }
    }
}
