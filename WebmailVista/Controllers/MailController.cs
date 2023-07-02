using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using Webmail.Core.Entities;
using WebmailVista.Models;

namespace WebmailVista.Controllers
{
    public class MailController : Controller
    {
        string ruta = "http://10.125.30.247:5280/api/Email/";
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Redactar()
        {
            /**aca va la logica de traer desde la bd*/
           
            return View();
        }
        public async Task<IActionResult> BandejaEntrada()
        {
            /**aca va la logica de traer desde la bd*/
            List<Email> emails = new List<Email>();
            using (var httpClient = new HttpClient())
            {


                string api = ruta += "bandejaEntrada/" + 1;


                var data = await httpClient.GetStringAsync(api);
                Respuesta<Email> response = JsonSerializer.Deserialize<Respuesta<Email>>(data);
                if (response.code == 200)
                {

                    emails = response.docs;




                    return View(emails);
                }
                else
                {
                    //   ViewData["MENSAJE"] = "No tienes credenciales correctas";
                    return RedirectToAction("ErrorAcceso", "Login");
                }
            }

            return View();

            }


            public async Task<IActionResult> BandejaSalida()
        {
            /**aca va la logica de traer desde la bd*/
            List<Email> emails = new List<Email>();
            using (var httpClient = new HttpClient())
            {


                string api =ruta += "bandejaSalida/" + 1 ;


                var data = await httpClient.GetStringAsync(api);
                Respuesta<Email> response = JsonSerializer.Deserialize<Respuesta<Email>>(data);
                if (response.code == 200)
                {

                    emails = response.docs;




                    return View(emails);
                }
                else
                {
                    //   ViewData["MENSAJE"] = "No tienes credenciales correctas";
                    return RedirectToAction("ErrorAcceso", "Login");
                }


                return View();
            }

        }

    }
}
