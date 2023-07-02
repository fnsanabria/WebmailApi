using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebmailConsola.Respuesta
{
    public class Respuesta<T>
    {
        public int code { get; set; }
        public string message { get; set; }
        public T? data { get; set; }
        public List<T?> docs { get; set; }
    }
}
