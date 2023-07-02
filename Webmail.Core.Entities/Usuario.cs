using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Webmail.Core.Entities
{
   
        [Table("Usuarios")]
        public class Usuario
    {
        [Key]
        public int UsuarioId { get; set; }
        public string Nombre { get; set; }
        public string CorreoElectronico { get; set; }

         public string Pass { get; set; }

        }
    
}
