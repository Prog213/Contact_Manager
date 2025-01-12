using Contact_Manager.Models;

namespace Contact_Manager.Repositories.Interfaces
{
    public interface IContactRepository
    {
        Task<List<Contact>> GetAllContactsAsync();
        Task<Contact?> GetContactByIdAsync(int id);
        Task AddContactsAsync(List<Contact> contacts);
        Task DeleteContactAsync(Contact contact);
        Task UpdateContactAsync(Contact contact);
    }
}
