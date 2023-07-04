using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Webmail.Core.Entities;
using WebmailConsola.Respuesta;

namespace WebmailConsola.Servicios
{
    public  class UsuarioService
    {
        string ruta = "";


        public static async Task<bool> Login(string email, string password)
        {
          


            using (var httpClient = new HttpClient())
            {

                string api = "";
                api = "http://10.125.30.247:5280/api/Usuario/login/" + email + "/" + password;


                var data = await httpClient.GetStringAsync(api);
                Respuesta<Usuario> response = JsonSerializer.Deserialize<Respuesta<Usuario>>(data);
                if (response.code == 200)
                {


                    UsuarioLogin.UsuarioLogin.Id = response.data.UsuarioId;
                    return true;
                }
                else
                {
                    //   ViewData["MENSAJE"] = "No tienes credenciales correctas";
                    return false;
                }

            }



        }



    }
}
