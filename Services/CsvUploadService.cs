using AutoMapper;
using Contact_Manager.Models;
using Contact_Manager.Repositories.Interfaces;
using Contact_Manager.Services.Interfaces;
using CsvHelper;
using System.Globalization;
using System.Text;

namespace Contact_Manager.Services
{
    public class CsvUploadService(IContactRepository contactRepository, IMapper mapper) : ICsvUploadService
    {
        public async Task UploadContactsFromCsv(IFormFile file)
        {
            using var stream = new MemoryStream();
            await file.CopyToAsync(stream);
            stream.Position = 0;

            using var reader = new StreamReader(stream, Encoding.UTF8);
            using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);

            var records = csv.GetRecords<AddContact>().ToList();

            if (records == null || records.Count == 0)
            {
                throw new Exception("The CSV file is empty or improperly formatted.");
            }

            await contactRepository.AddContactsAsync(mapper.Map<List<Contact>>(records));
        }
    }
}
