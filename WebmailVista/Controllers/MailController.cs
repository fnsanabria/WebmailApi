using Microsoft.AspNetCore.Mvc;
using Webmail.Core.Entities;

namespace WebmailVista.Controllers
{
    public class MailController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Detalle()
        {
            /**aca va la logica de traer desde la bd*/
            var mail = new Email
            {
                EmailId = 1,
                Contenido="contenido de email"
                
            };
            return View(mail);
        }
    }
}
