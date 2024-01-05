using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EncrypterAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PingController : ControllerBase
    {

        // GET api/<PingController>/5
        [HttpGet()]
        public string Ping()
        {
            return "Pong";
        }
    }
}
