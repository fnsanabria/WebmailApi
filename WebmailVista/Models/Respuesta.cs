namespace WebmailVista.Models
{
    public  class Respuesta<T>
    {
        public int code { get; set; }
        public string message { get; set; }
        public T? data { get; set; }
        public List<T?> docs { get; set; }
    }
}
