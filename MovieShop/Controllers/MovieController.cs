using ApplicationCore.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MovieShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        
        public string Get()
        {
            return "Fast and Furious";
        }

        [Route("[action]/{id:min(1)}")]
        public string GetById(int id)
        {
            return "Movie = " + id;
        }

        [Route("byquery")]
        public IActionResult GetByQuery(int id, string name)
        {
            return Ok(name);
        }

        [Route("byBody")]
        public IActionResult GetByBody(Genre g)
        {
            string str = "";
            str += g.Name ;
            return Ok("Result = " +str);
        }
    }
}
