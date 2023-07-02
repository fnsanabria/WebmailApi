using Microsoft.AspNetCore.Mvc;
using System.Text;
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
                      
            return View();
        }

        public IActionResult CorreoExitoso()
        {

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CrearMail([Bind("Destinatario,Asunto,Contenido")] Email email)
        {
            using (var httpClient = new HttpClient())
            {
                var em =  email;

                
                string api = "http://10.125.30.247:5280/api/Email";
                var em2 = new
                {
                    emailId = 0,
                    remitenteId =1,
                    destinatarioId =2,
                    asunto = "anda el correo",
                    contenido = "tratando de insertar contenido",
                    fecha = "2023-07-02T21:02:37.308Z",
                    leido = true,
                    bandejaEntrada = false,
                    bandejaSalida = true,

                };

                var data = await httpClient.PostAsJsonAsync(api, em2);
               // Respuesta<Email> response = JsonSerializer.Deserialize<Respuesta<Email>>(data);
                var res = data.Content.ReadAsStringAsync().Result;
                Respuesta<Email> response = JsonSerializer.Deserialize<Respuesta<Email>>(res);
                if (response.code == 200)
                {




                    return RedirectToAction("CorreoExitoso", "Mail");
                }
                else
                {
                    //   ViewData["MENSAJE"] = "No tienes credenciales correctas";
                    return RedirectToAction("ErrorAcceso", "Login");
                }
                return RedirectToAction("Index", "Mail");
            }
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
