using Microsoft.AspNetCore.Mvc;
using WebmailApi.Data;
using Webmail.Core.Entities;
using System.Text.Json;
using System.Collections.Generic;

namespace WebmailApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
       
        [HttpGet("login/{user}/{pass}")]
        public ActionResult Login(string user, string pass)
        {
             using (var DBcontext = new EmailDBContext())
            {
               

                try
                {
                    string passCifrado = Cifrado.Cifrado.cifrar(pass, 17);

                    var result =   DBcontext.Usuarios.SingleOrDefault(x => x.CorreoElectronico == user && x.Pass== passCifrado);

                    if (result != null)
                    {
                        var respuesta = new
                        {
                            code = 200,
                            message ="login exitoso !!!",
                            data = result
                        };
                        string docs= JsonSerializer.Serialize(respuesta);
                        return Ok(docs);
                    }
                    else { 
                   
                        var respuesta = new
                        {
                            code = 400,
                            message = "crendeciales incorrectas !!!",
                          
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
        
       [HttpGet("buscarCorreo/{email}")]
       public ActionResult BuscarCorreo(string email)
        {
            using (var DBcontext = new EmailDBContext())
            {
                try
                {
                    var result = (from datos in DBcontext.Usuarios
                                   where datos.CorreoElectronico == email
                                   select datos).First();


                    //var result = DBcontext.Usuarios.SingleOrDefault(u => u.CorreoElectronico.Contains(email));
                    if (result != null)
                    {
                        var respuesta = new
                        {
                            code = 200,
                            message = "usuario existe !!!",
                            data = result
                        };
                        string docs = JsonSerializer.Serialize(respuesta);
                        return Ok(docs);
                    }
                    else
                    {

                        var respuesta = new
                        {
                            code = 400,
                            message = "usuario no existe !!!",

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
        


        [HttpGet()]
        public async Task<ActionResult<int>> GetListUsuario()
        {
            var cantidad=0;
            using (var DBcontext = new EmailDBContext())
            {
                try
                {
                    cantidad = DBcontext.Usuarios.Count();
                   
                }
                catch (Exception ex)
                {
                  
                }

              

                return cantidad;
            }
        }
    }
}
