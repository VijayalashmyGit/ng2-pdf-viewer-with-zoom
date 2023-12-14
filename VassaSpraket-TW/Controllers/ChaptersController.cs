using VassaSpraket_TW.Data.Repositories;
using Microsoft.AspNetCore.Mvc;


namespace VassaSpraket_TW.Controllers
{
    [ApiController]
    [Route("Chapters")]
    
    public class ChaptersController : ControllerBase
    {
        private readonly IChaptersRepository _Chaptersrepository;

        public ChaptersController(IChaptersRepository repository)
        {
            _Chaptersrepository = repository;
        }

        [HttpGet]
        [Route("GetAllChapters")]
        public async Task<IActionResult> GetAllChapters()
        {
            var entities = await _Chaptersrepository.GetAllChapters();
            return Ok(entities);
        }       

    }
}
