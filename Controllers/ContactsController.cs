using Crito.Models;
using Crito.Services;
using Microsoft.AspNetCore.Mvc;
using Umbraco.Cms.Core.Cache;
using Umbraco.Cms.Core.Logging;
using Umbraco.Cms.Core.Routing;
using Umbraco.Cms.Core.Services;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Infrastructure.Persistence;
using Umbraco.Cms.Web.Website.Controllers;

namespace Crito.Controllers
{
   
    public class ContactsController : SurfaceController
    {
        private readonly ContactService _contactService;
        public ContactsController(IUmbracoContextAccessor umbracoContextAccessor, IUmbracoDatabaseFactory databaseFactory, ServiceContext services, AppCaches appCaches, IProfilingLogger profilingLogger, IPublishedUrlProvider publishedUrlProvider, ContactService contactService) : base(umbracoContextAccessor, databaseFactory, services, appCaches, profilingLogger, publishedUrlProvider)
        {
            _contactService = contactService;
        }

        [HttpPost]
        public async Task <IActionResult> Index(ContactForm contactForm)
        {
            if (!ModelState.IsValid)
                return CurrentUmbracoPage();

            //try
            //{
            //    using (var mail = new MailService("no-reply@example.com", "smtp.live.com", 587, "exemple@hotmail.com", "123456789"))
            //    {
            //        // Skicka meddelandet till mottagaren
            //        await mail.SendAsync(contactForm.Email, "Your request was received.", "Hi, your request was received, and we will be in contact with you as soon as possible.");

            //        // Skicka en kopia till dig själv
            //        await mail.SendAsync("exemple@hotmail.com", $"{contactForm.Email} sent a contact request.", contactForm.Message);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    // Hantera eventuella undantag som uppstår vid skickande av e-post här
            //    Console.WriteLine($"Ett fel uppstod: {ex.Message}");
            //}


            var contact = new ContactForm()
            {
                Email = contactForm.Email,
                Name = contactForm.Name,
                Message = contactForm.Message
            };
            await _contactService.AddContactAsync(contact);


            return LocalRedirect(contactForm.RedirectUrl ?? "/");
        }
    }
}
