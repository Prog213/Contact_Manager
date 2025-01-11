using Contact_Manager.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Contact_Manager.Controllers
{
    public class ContactsController(AppDbContext context) : Controller
    {
        [HttpGet]
        public async Task<IActionResult> List()
        {
            var contacts = await context.Contacts.ToListAsync();
            return View(contacts);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var contact = await context.Contacts.FindAsync(id);

            if (contact == null)
            {
                return NotFound();
            }

            context.Contacts.Remove(contact);
            await context.SaveChangesAsync();

            return RedirectToAction(nameof(List));
        }

    }
}
