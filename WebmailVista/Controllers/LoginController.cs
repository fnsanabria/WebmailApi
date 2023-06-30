using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
namespace WebmailVista.Controllers
{
    public class LoginController:Controller
    {
       
        public IActionResult Index()
        {
            return View();
        }
        public bool login(string user,string pass)
        {
           
            using (var httpClient= new HttpClient())
            {
                var body = new
                {
                    user = user,
                    pass = pass,
                };
                string json = JsonSerializer.Serialize(body);   //using Newtonsoft.Json

                StringContent httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
                var resul = httpClient.PostAsync("https://10.125.30.247/api/Usuario/login/", httpContent);
            }
            
            return false;
        }
       
    }
}
