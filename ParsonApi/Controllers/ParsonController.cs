using Microsoft.AspNetCore.Mvc;
using ParsonApi.Models;
using ParsonApi.Models.Data;
using ParsonApi.Repositories;

namespace ParsonApi.Controllers
{
    [ApiController]
    [Route("api/[controller]s")]

    public class ParsonController : Controller
    {
        private readonly ICRUDRepository<Parson> _crudRepository;

        public ParsonController(ICRUDRepository<Parson> crudRepository)
        {
            _crudRepository = crudRepository;
        }

        [HttpGet]
        //[Route("Index")]
        public async Task<IEnumerable<Parson>> Index()
        {
            return await _crudRepository.GetEntitiesAsync();
        }
    }
}
