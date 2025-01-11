using AutoMapper;
using Contact_Manager.Data;
using Contact_Manager.Models;
using CsvHelper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Formats.Asn1;
using System.Globalization;
using System.Text;

namespace Contact_Manager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileUploadController(AppDbContext context, IMapper mapper) : ControllerBase
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
                using var stream = new MemoryStream();
                await file.CopyToAsync(stream);
                stream.Position = 0;

                using var reader = new StreamReader(stream, Encoding.UTF8);
                using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);

                var records = csv.GetRecords<AddContact>().ToList();

                if (records == null || records.Count == 0)
                {
                    return BadRequest("The CSV file is empty or improperly formatted.");
                }

                context.Contacts.AddRange(mapper.Map<List<Contact>>(records));
                await context.SaveChangesAsync();

                return Ok(new { message = "File uploaded and data saved successfully." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
