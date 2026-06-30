using Microsoft.AspNetCore.Mvc;
using Search.Api.Services;
using Search.Api.DTOs;

namespace Search.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ImportController : ControllerBase
    {
        private readonly ImportService _service;

        public ImportController(ImportService service)
        {
            _service = service;
        }

        [HttpGet("ping")]
        public IActionResult Ping()
        {
            return Ok(_service.Ping());
        }

        [HttpPost("upload")]
        public async Task<IActionResult> Upload([FromForm] UploadExcelRequest request)
        {
            if (request.File == null || request.File.Length == 0)
                return BadRequest("No file selected.");

            int total = await _service.ImportExcelAsync(request.File);

            return Ok(new
            {
                Imported = total
            });
        }
    }
}