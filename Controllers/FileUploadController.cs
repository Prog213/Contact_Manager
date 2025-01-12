using Contact_Manager.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Contact_Manager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileUploadController(ICsvUploadService csvUploadService) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> UploadCsv(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest("No file was uploaded.");
            }

            var allowedExtensions = new[] { ".csv" };
            var extension = Path.GetExtension(file.FileName).ToLowerInvariant();
            if (!allowedExtensions.Contains(extension))
            {
                return BadRequest("Invalid file type. Only CSV files are allowed.");
            }

            try
            {
                await csvUploadService.UploadContactsFromCsv(file);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest($"Bad request: {ex.Message}");
            }
        }
    }
}
