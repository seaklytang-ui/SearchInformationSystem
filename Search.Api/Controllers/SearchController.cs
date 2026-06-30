using Microsoft.AspNetCore.Mvc;
using Search.Api.Services;

namespace Search.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SearchController : ControllerBase
    {
        private readonly SearchService _searchService;

        public SearchController(SearchService searchService)
        {
            _searchService = searchService;
        }

        [HttpGet]
        public async Task<IActionResult> Search([FromQuery] string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
                return BadRequest("Keyword is required.");

            var result = await _searchService.SearchAsync(keyword);

            return Ok(result);
        }

        [HttpGet("ping")]
        public IActionResult Ping()
        {
            return Ok("API is working.");
        }

        [HttpGet("count")]
        public async Task<IActionResult> Count()
        {
            var total = await _searchService.CountAsync();

            return Ok(new
            {
                Total = total
            });
        }

        [HttpGet("landno")]
        public async Task<IActionResult> SearchByLandNo(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
                return BadRequest("Keyword is required.");

            var result = await _searchService.SearchByLandNoAsync(keyword);

            return Ok(result);
        }
    }
}