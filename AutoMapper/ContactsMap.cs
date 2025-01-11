using AutoMapper;
using Contact_Manager.Models;

namespace Contact_Manager.AutoMapper
{
    public class ContactsMap : Profile
    {
        public ContactsMap()
        {
            CreateMap<AddContact, Contact>();
        }
    }
}
