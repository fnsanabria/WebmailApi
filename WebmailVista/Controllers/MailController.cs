using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
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
            if(UsuarioLogin.Id > 0) { 
            return View();
            }
            return RedirectToAction("ErrorAcceso", "Login");
        }

       

      


        public IActionResult CorreoExitoso()
        {

            if (UsuarioLogin.Id > 0)
            {
                return View();
            }
            return RedirectToAction("ErrorAcceso", "Login");
        }
        public IActionResult DestinatarioError()
        {

            if (UsuarioLogin.Id > 0)
            {
                return View();
            }
            return RedirectToAction("ErrorAcceso", "Login");
        }

        public IActionResult CorreoError()
        {

            if (UsuarioLogin.Id > 0)
            {
                return View();
            }
            return RedirectToAction("ErrorAcceso", "Login");
        }
        [HttpPost]
        public async Task<IActionResult> CrearMail([Bind("Destinatario,Asunto,Contenido")] Email email)
        {
            if (UsuarioLogin.Id > 0)
            {
                using (var httpClient = new HttpClient())
                {

                    string[] usuarios = email.Destinatario.CorreoElectronico.Split(',');

                    bool isError = false;

                    List<Usuario> user = new List<Usuario>();

                    foreach (var usuar in usuarios)
                    {
                        var desti = await httpClient.GetStringAsync("http://10.125.30.247:5280/api/Usuario/buscarCorreo/" + usuar);
                        Respuesta<Usuario> d = JsonSerializer.Deserialize<Respuesta<Usuario>>(desti);
                        if (d.code == 200)
                        {
                            user.Add(d.data);
                        }
                        else
                        {
                            return RedirectToAction("DestinatarioError", "Mail");
                        }
                    }


                    DateTime dateTime = DateTime.Now;

                    string api = "http://10.125.30.247:5280/api/Email";

                    var remi = await httpClient.GetStringAsync("http://10.125.30.247:5280/api/Usuario/buscarCorreo/usuario@usuario");
                    Respuesta<Usuario> r = JsonSerializer.Deserialize<Respuesta<Usuario>>(remi);



                    foreach (var usuario in user)
                    {
                        try
                        {
                            Email e = new Email()
                            {
                                EmailId = 0,
                                RemitenteId = r.data.UsuarioId,
                                DestinatarioId = usuario.UsuarioId,
                                Asunto = email.Asunto,
                                Contenido = email.Contenido,
                                Fecha = dateTime,
                                Leido = false,
                                BandejaEntrada = false,
                                BandejaSalida = true,


                            };



                            var json = JsonSerializer.Serialize(e);
                            var m = new StringContent(json, Encoding.UTF8, "application/json");
                            var data = await httpClient.PostAsync(api, m);

                            var res = data.Content.ReadAsStringAsync().Result;
                            Respuesta<Email> response = JsonSerializer.Deserialize<Respuesta<Email>>(res);
                            if (response.code == 200)
                            {



                            }
                            else
                            {

                                isError = true;
                            }

                        }
                        catch (Exception)
                        {

                            return RedirectToAction("CorreoError", "Mail");
                        }

                    }
                    if (!isError)
                    {
                        return RedirectToAction("CorreoExitoso", "Mail");
                    }
                    else
                    {
                        return RedirectToAction("CorreoError", "Mail");
                    }


                }
            }
            else
            {
                return RedirectToAction("ErrorAcceso", "Login");
            }
           

            
        }
        
            public async Task<IActionResult> BandejaEntrada()
        {
            if (UsuarioLogin.Id > 0)
            {
                /**aca va la logica de traer desde la bd*/
                List<Email> emails = new List<Email>();
                using (var httpClient = new HttpClient())
                {


                    string api = ruta += "bandejaEntrada/" + UsuarioLogin.Id;


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
            }
            else
            {
                return RedirectToAction("ErrorAcceso", "Login");
            }
                   

          

            }


            public async Task<IActionResult> BandejaSalida()
        {
            if (UsuarioLogin.Id > 0)
            {
                /**aca va la logica de traer desde la bd*/
                List<Email> emails = new List<Email>();
                using (var httpClient = new HttpClient())
                {


                    string api = ruta += "bandejaSalida/" + UsuarioLogin.Id;


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
            else
            {
                return RedirectToAction("ErrorAcceso", "Login");
            }
           

           

        }

    }
}
