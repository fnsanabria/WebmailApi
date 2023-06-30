using Microsoft.AspNetCore.Mvc;
using WebmailApi.Data;
using Webmail.Core.Entities;


namespace WebmailApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {

        [HttpPost("login")]
        public async Task<ActionResult<Usuario>> Login(string user,string pass)
        {
            using (var DBcontext = new EmailDBContext())
            {
                Usuario use = new Usuario();
                try
                {
                    var obj =  DBcontext.Usuarios.Where(u => u.CorreoElectronico==user).Where(u => u.Pass == pass).First();
                    use = (Usuario)obj;
                    if (use == null)
                    {
                        return new Usuario();
                    }
                }
                catch (Exception ex)
                {
                    return new Usuario();
                }



                return use;
            }
        }
        
        // GET: api/UsuarioCriminalistica/5
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
