using Crito.Contexts;
using Crito.Models;

namespace Crito.Services;

public class ContactService
{
    private readonly DataContextName _contextName;

    public ContactService(DataContextName contextName)
    {
        _contextName = contextName;
    }

    public async Task AddContactAsync(ContactForm contactForm)
    {
        _contextName.Contacts.Add(new ContactEntity 
        {
            Email = contactForm.Email,
            Name = contactForm.Name,
            Message = contactForm.Message
        });
        await _contextName.SaveChangesAsync();
    }
}
