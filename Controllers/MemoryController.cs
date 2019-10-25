using set_memory_usage.Services;
using Microsoft.AspNetCore.Mvc;

namespace set_memory_usage.Controllers
{

    [Route("/")]
    [Route("api/[controller]")]
    [ApiController]
    public class MemoryController : ControllerBase
    {

        private IMemoryService _memoryService;

        public MemoryController(IMemoryService memoryService)
        {
            _memoryService = memoryService;
        }

        // Reset Memory
        [HttpGet]
        public ActionResult<string> Get()
        {
            return _memoryService.Reset();
        }

        // Set Memory
        [HttpGet("{size}")]
        public ActionResult<string> Get(int size = 1)
        {
            return _memoryService.Set(size);
        }

        // Get Memory
        [HttpGet]
        [Route("api/[controller]/get")]
        public ActionResult<string> GetSize()
        {
            return _memoryService.Get();
        }

    }
}
