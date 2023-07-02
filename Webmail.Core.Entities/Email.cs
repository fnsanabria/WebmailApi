using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Webmail.Core.Entities
{
    public class Email
    {
        [Key]
        public int EmailId { get; set; }
   
        public int RemitenteId { get; set; }       
        
        
        public int DestinatarioId { get; set; }
       
       
        public string Asunto { get; set; }
        public string Contenido { get; set; }

        public DateTime Fecha { get; set; }
        public bool Leido { get; set; }
        public bool BandejaEntrada { get; set; }
        public bool BandejaSalida { get; set; }

        [ForeignKey("RemitenteId")]
        public virtual Usuario? Remitente { get; set; }

        [ForeignKey("DestinatarioId")]
        public virtual Usuario? Destinatario { get; set; }
    }
}
