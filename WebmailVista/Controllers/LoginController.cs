using Microsoft.AspNetCore.Mvc;
using System;
using System.Net.NetworkInformation;
using System.Text;
using System.Text.Json;
using Webmail.Core.Entities;
using WebmailVista.Models;



namespace WebmailVista.Controllers
{
    public class LoginController:Controller
    {
        string ruta = "http://10.125.30.247:5280/api/Usuario/";
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ErrorAcceso()
        {
            return View();
        }
        

        [HttpPost]
        public async Task<IActionResult>  Login(string email, string password)
        {
           Usuario u = new Usuario();

           
            using (var httpClient= new HttpClient())
            {


               string api= ruta+="login/"+email+"/"+password;
                

                var data = await httpClient.GetStringAsync(api);
               Respuesta<Usuario> response =JsonSerializer.Deserialize<Respuesta<Usuario>>(data);
                if (response.code == 200)
                {
                   
                   
                  

                    return RedirectToAction("Index", "Mail");
                }
                else
                {
                    //   ViewData["MENSAJE"] = "No tienes credenciales correctas";
                    return RedirectToAction("ErrorAcceso", "Login");
                }

            }
           
            

        }
       
    }
}
