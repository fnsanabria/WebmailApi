using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using Webmail.Core.Entities;
using WebmailVista.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
        
            public IActionResult CorreoError()
        {

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CrearMail([Bind("Destinatario,Asunto,Contenido")] Email email)
        {
            using (var httpClient = new HttpClient())
            {
               
              
                DateTime dateTime = DateTime.Now;

                string api = "http://10.125.30.247:5280/api/Email";
               
                var remi = await httpClient.GetStringAsync("http://10.125.30.247:5280/api/Usuario/buscarCorreo/usuario@usuario");
                var desti = await httpClient.GetStringAsync("http://10.125.30.247:5280/api/Usuario/buscarCorreo/flor@flor");

                Respuesta<Usuario> r = JsonSerializer.Deserialize<Respuesta<Usuario>>(remi);
                Respuesta<Usuario> d = JsonSerializer.Deserialize<Respuesta<Usuario>>(remi);

                Email e = new Email()
                {
                    EmailId = 0,
                    RemitenteId = r.data.UsuarioId,
                    DestinatarioId = d.data.UsuarioId,
                    Asunto = email.Asunto,
                    Contenido = email.Contenido,
                    Fecha = dateTime,
                    Leido = false,
                    BandejaEntrada = false,
                    BandejaSalida = true,
                //    Destinatario=d.data,
                 //   Remitente = r.data,

            };


               





                try
                {
                   

                    var json = JsonSerializer.Serialize(e);
                    var m = new StringContent(json, Encoding.UTF8, "application/json");
                    var data = await httpClient.PostAsync(api, m);
             
                var res = data.Content.ReadAsStringAsync().Result;
                Respuesta<Email> response = JsonSerializer.Deserialize<Respuesta<Email>>(res);
               

                
                
                if (response.code == 200)
                {




                    return RedirectToAction("CorreoExitoso", "Mail");
                }
                else
                {
                        return RedirectToAction("CorreoError", "Mail");

                    }
                }
                catch (Exception)
                {

                    return RedirectToAction("CorreoError", "Mail");
                }
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
