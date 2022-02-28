using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ApplicationCore.Entities;
using ApplicationCore.Contracts.Repositories;
using Infrastructure.Repositories;

namespace Movieshop.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        IMovieRepository _movieRepository;
        public MovieController(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        [Route("{id}/name/{name}")]
        public IActionResult GetById(int id, string name)
        {
            return Ok($"{id} - {name}");
        }

        [Route("byquery")]
        public IActionResult GetByQuery(int id, string name)
        {
            return Ok(name);
        }

        [Route("byBody")]
        public IActionResult GetData(Genre g)
        {
            string str = "";
            str += g.Name;

            return Ok("Result = " + str);
        }

        [Route("byboth")]
        public IActionResult GetByBoth([FromQuery] int rating, [FromForm] Genre g, [FromHeader] string jwt)
        {
            return Ok(rating + " " + g.Name + " " + jwt);
        }
    }
}