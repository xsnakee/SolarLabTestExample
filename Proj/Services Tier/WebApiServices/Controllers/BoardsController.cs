using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SolarLab.AppServices;
using SolarLab.WebApi.Contracts.Dto;

namespace WebApiServices.Controllers
{
    [Route("api/[controller]")]
    public class BoardsController : Controller
    {
        public BoardsController(IBoardService boardService)
        {
            _boardService = boardService;
        }

        protected readonly IBoardService _boardService;


        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "It's alive!" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            BoardDto board = _boardService
                    .GetBoardById(id);

            if (board == null)
            {
                return NotFound();
            }

            return Ok(board);
        }


        // GET api/getAdverts/5
        [HttpGet("getAdverts/{id}")]
        public List<string> GetAdverts(int id)
        {
            var board = _boardService
                    .GetAllAdverts(id);
            if (board == null)
            {
                return new List<string> { };
            }

            return board
                        .Select(x => x.Text)
                        .ToList();
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
