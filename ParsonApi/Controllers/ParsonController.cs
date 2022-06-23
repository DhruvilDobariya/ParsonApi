using Microsoft.AspNetCore.Mvc;
using ParsonApi.Models;
using ParsonApi.Models.Data;
using ParsonApi.Repositories;

namespace ParsonApi.Controllers
{
    [ApiController]
    //[Route("api/[controller]/")]

    public class ParsonController : Controller
    {
        private readonly ICRUDRepository<Parson> _crudRepository;

        public ParsonController(ICRUDRepository<Parson> crudRepository)
        {
            _crudRepository = crudRepository;
        }

        [HttpGet]
        [Route("api/[controller]s")]
        public async Task<ActionResult<IEnumerable<Parson>>> GetParsons()
        {
            var parsons = await _crudRepository.GetEntitiesAsync();
            if(parsons == null)
            {
                return NotFound(parsons);
            }
            return Ok(Json(parsons));
        }

        [HttpGet]
        [Route("api/[controller]/{id}")]
        public async Task<ActionResult<Parson>> GetParsonById(int id)
        {
            if(id <= 0)
            {
                return NotFound();
            }
            Parson parson = await _crudRepository.GetEntityByIdAsync(id);
            if(parson == null)
            {
                return NotFound(parson);
            }
            return Ok(parson);
        }

        [HttpPost]
        [Route("api/[controller]")]
        public async Task<ActionResult<Parson>> AddParsonAsync(Parson parson)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(Json(ModelState));
            }
            if (await _crudRepository.AddEntityAsync(parson))
            {
                return Created("~/api/Parson/", parson);
            }
            return Json(_crudRepository.Message);
        }

        [HttpPut]
        [Route("api/[controller]")]
        public async Task<ActionResult<Parson>> UpdateParsonAsync(Parson parson)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(Json(ModelState));
            }
            if (await _crudRepository.UpdateEntityAsync(parson))
            {
                return Ok(parson);
            }
            return Json(_crudRepository.Message);
        }

        [HttpDelete]
        [Route("api/[controller]/{id}")]
        public async Task<ActionResult<bool>> DeleteParsonAsync(int id)
        {
            if(id <= 0)
            {
                return BadRequest();
            }
            if(await _crudRepository.DeleteEntityAsync(id))
            {
                return Ok(true);
            }
            return NotFound(_crudRepository.Message);
        }
    }
}
