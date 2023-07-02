using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebmailConsola.Respuesta;
using System.Text.Json;
using Webmail.Core.Entities;

namespace WebmailConsola.Servicios
{
    public class EmailService
    {

        public static async Task<List<Email>> BandejaEntrada()
        {
            /**aca va la logica de traer desde la bd*/
            List<Email> emails = new List<Email>();
            using (var httpClient = new HttpClient())
            {

                string api = "";
                api += "http://10.125.30.247:5280/api/Email/bandejaEntrada/" + 1;


                var data = await httpClient.GetStringAsync(api);
                Respuesta<Email> response = JsonSerializer.Deserialize<Respuesta<Email>>(data);
                if (response.code == 200)
                {

                    emails = response.docs;


                    return emails;
                }
                else
                {
                    //   ViewData["MENSAJE"] = "No tienes credenciales correctas";
                    return new List<Email>();
                }
            }

            return new List<Email>();

        }


        public static async Task<List<Email>> BandejaSalida()
        {
            /**aca va la logica de traer desde la bd*/
            List<Email> emails = new List<Email>();
            using (var httpClient = new HttpClient())
            {


                string api = "";
                api += "http://10.125.30.247:5280/api/Email/bandejaSalida/" + 1;


                var data = await httpClient.GetStringAsync(api);
                Respuesta<Email> response = JsonSerializer.Deserialize<Respuesta<Email>>(data);
                if (response.code == 200)
                {

                    emails = response.docs;




                    return emails;
                }
                else
                {
                  
                    return new List<Email>();
                }


                return new List<Email>();
            }

        }


    }
}
