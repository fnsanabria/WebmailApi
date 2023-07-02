using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text.Json;
using Webmail.Core.Entities;
using WebmailApi.Data;

namespace WebmailApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {

        [HttpGet("bandejaEntrada/{id}")]
        public  ActionResult BandajaEntrada(int id)
        {
            /*bandeja entrada remitente banadejaEntrada false y [DestinatarioId] mi id*/
            using (var DBcontext = new EmailDBContext())
            {
                try
                {
                  
                    var result = (from datos in DBcontext.Emails
                                   .Include(e => e.Remitente)
                                   .Include(e=> e.Destinatario)// Carga anticipada de la tabla relacionada "Usuario"
                                  where datos.DestinatarioId == id
                                  where datos.BandejaEntrada == false
                                  select datos).ToList();
                   
                    if (result != null)
                    {
                        var respuesta = new
                        {
                            code = 200,
                            message = "se recupero bandeja de salida con exito",
                            docs = result
                        };
                        string docs = JsonSerializer.Serialize(respuesta);
                        return Ok(docs);
                    }
                    else
                    {

                        var respuesta = new
                        {
                            code = 300,
                            message = "sin datos",

                        };

                        string docs = JsonSerializer.Serialize(respuesta);
                        return Ok(docs);

                    }
                }
                catch (Exception ex)
                {
                    var respuesta = new
                    {
                        code = 500,
                        message = ex.Message,

                    };

                    string docs = JsonSerializer.Serialize(respuesta);
                    return Ok(docs);
                }



              
            }
        }


        [HttpGet("bandejaSalida/{id}")]
        public ActionResult BandajaSalida(int id)
        {
            /*bandejasalida si es true es porque recibio envio email y remitente es mi id*/
            using (var DBcontext = new EmailDBContext())
            {
                try
                {
                    var result = (from datos in DBcontext.Emails
                                   .Include(e => e.Remitente)
                                   .Include(e => e.Destinatario)// Carga anticipada de la tabla relacionada "Usuario"
                                  where datos.RemitenteId == id
                                  where datos.BandejaSalida == true
                                  select datos).ToList();

                    if (result != null)
                    {
                        var respuesta = new
                        {
                            code = 200,
                            message = "se recupero bandeja de salida con exito",
                            docs = result
                        };
                        string docs = JsonSerializer.Serialize(respuesta);
                        return Ok(docs);
                    }
                    else
                    {

                        var respuesta = new
                        {
                            code = 300,
                            message = "sin datos",

                        };

                        string docs = JsonSerializer.Serialize(respuesta);
                        return Ok(docs);

                    }
                }
                catch (Exception ex)
                {
                    var respuesta = new
                    {
                        code = 500,
                        message = ex.Message,

                    };

                    string docs = JsonSerializer.Serialize(respuesta);
                    return Ok(docs);
                }




            }
        }


        [HttpPost()]
        public async Task<ActionResult> Insert(Email email)
        {
            
            
            /*bandeja entrada remitente banadejaEntrada false y [DestinatarioId] mi id*/
            using (var DBcontext = new EmailDBContext())
            {
                try
                {
                    var des = (from datos in DBcontext.Usuarios
                                  where datos.UsuarioId == email.DestinatarioId
                                  select datos).First();
                    var rem = (from datos in DBcontext.Usuarios
                               where datos.UsuarioId == email.RemitenteId
                               select datos).First();
                 
                    email.Destinatario = des;
                    email.Remitente = rem;
                    DBcontext.Emails.Add(email);
                    var result = await  DBcontext.SaveChangesAsync();

                    if (result != null)
                    {
                        var respuesta = new
                        {
                            code = 200,
                            message = "se creo con exito",
                           
                        };
                        string docs = JsonSerializer.Serialize(respuesta);
                        return Ok(docs);
                    }
                    else
                    {

                        var respuesta = new
                        {
                            code = 300,
                            message = "sin datos",

                        };

                        string docs = JsonSerializer.Serialize(respuesta);
                        return Ok(docs);

                    }
                }
                catch (Exception ex)
                {
                    var respuesta = new
                    {
                        code = 500,
                        message = ex.Message,

                    };

                    string docs = JsonSerializer.Serialize(respuesta);
                    return Ok(docs);
                }




            }
        }
    }
}
