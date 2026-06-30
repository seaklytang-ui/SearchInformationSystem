using Microsoft.AspNetCore.Http;

namespace Search.Api.DTOs
{
    public class UploadExcelRequest
    {
        public IFormFile File { get; set; } = null!;
    }
}