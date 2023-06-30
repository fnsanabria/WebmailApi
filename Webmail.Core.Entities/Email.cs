using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        public bool Bandeja { get; set; }
    }
}
