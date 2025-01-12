namespace Contact_Manager.Services.Interfaces
{
    public interface ICsvUploadService
    {
        Task UploadContactsFromCsv(IFormFile file);
    }
}