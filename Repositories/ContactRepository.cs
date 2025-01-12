using Contact_Manager.Data;
using Contact_Manager.Models;
using Contact_Manager.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Contact_Manager.Repositories
{
    public class ContactRepository(AppDbContext context) : IContactRepository
    {
        public async Task<List<Contact>> GetAllContactsAsync()
        {
            return await context.Contacts.ToListAsync();
        }

        public async Task<Contact?> GetContactByIdAsync(int id)
        {
            return await context.Contacts.FindAsync(id);
        }

        public async Task AddContactsAsync(List<Contact> contacts)
        {
            await context.Contacts.AddRangeAsync(contacts);
            await context.SaveChangesAsync();
        }

        public async Task DeleteContactAsync(Contact contact)
        {
            context.Contacts.Remove(contact);
            await context.SaveChangesAsync();
        }

        public async Task UpdateContactAsync(Contact contact)
        {
            await context.SaveChangesAsync();
        }
    }
}
