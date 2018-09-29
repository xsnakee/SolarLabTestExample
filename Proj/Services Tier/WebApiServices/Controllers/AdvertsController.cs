using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SolarLab.AppServices;
using SolarLab.WebApi.Contracts.Dto;

namespace WebApiServices.Controllers
{
    [Route("api/[controller]")]
    public class AdvertsController : Controller
    {
        public AdvertsController(IAdvertService advertService)
        {
            _advertService = advertService;
        }

        protected readonly IAdvertService _advertService;


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
            AdvertDto advert = _advertService
                    .GetAdvertById(id);

            if (advert == null)
            {
                return NotFound();
            }

            return Ok(advert);
        }


        // GET api/getComments/5
        [HttpGet("getComments/{id}")]
        public List<string> GetAdvertComments(int id)
        {
            var advert = _advertService
                    .GetAllAdvertComments(id);
            if (advert == null)
            {
                return new List<string> { };
            }

            return advert
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
