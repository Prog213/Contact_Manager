using AutoMapper;
using Contact_Manager.Data;
using Contact_Manager.Models;
using Contact_Manager.Repositories;
using Contact_Manager.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Contact_Manager.Controllers
{
    public class ContactsController(IContactRepository contactRepository, IMapper mapper) : Controller
    {
        [HttpGet]
        public async Task<IActionResult> List()
        {
            var contacts = await contactRepository.GetAllContactsAsync();
            return View(contacts);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var contact = await contactRepository.GetContactByIdAsync(id);

            if (contact == null)
            {
                return NotFound();
            }

            await contactRepository.DeleteContactAsync(contact);
            return RedirectToAction(nameof(List));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [FromBody] UpdateContact updatedContact)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var contact = await contactRepository.GetContactByIdAsync(id);
            if (contact == null)
            {
                return NotFound();
            }

            mapper.Map(updatedContact, contact);
            await contactRepository.UpdateContactAsync(contact);

            return RedirectToAction(nameof(List));
        }

    }
}
