// See https://aka.ms/new-console-template for more information
using Webmail.Core.Entities;
using WebmailConsola.Servicios;

int intentos = 0;
do
{
    Console.WriteLine("Bienvenido al sistema web mail");
    Console.WriteLine("Ingrese usuario");
    string usuario = Console.ReadLine();
    Console.WriteLine("Ingrese contraseña");
    string pass = Console.ReadLine();

    bool isExiste = await UsuarioService.Login(usuario, pass);
    if (isExiste)
    {
        Console.WriteLine("ingreso correcto");
        break;
    }
    else { Console.WriteLine("error de ingreso intente de nuevo");
    intentos++;
    }
} while (intentos < 2);

if (intentos == 2)
{
    Console.WriteLine("demasionado intentos ");
}
else
{

    Console.WriteLine("Menu");
    Console.WriteLine("Seleccione una opcion");
    int op = int.Parse(Console.ReadLine());
    List<Email> emails = new List<Email>();
    switch (op)
    {
        
        case 1: 
            {
                Console.WriteLine("Bandeja de entrada"); 
             emails= await EmailService.BandejaEntrada();

                foreach (var item in emails)
                {

                    Console.WriteLine($"Remitente = {item.Remitente.CorreoElectronico}" +
                        $" contenido = {item.Contenido} ");
                }
                break; 
            }
        case 2: {
                Console.WriteLine("Bandeja de salida");
             emails = await EmailService.BandejaSalida();
                
                foreach (var item in emails)
                {
                    
                    Console.WriteLine($"Destinario = {item.Destinatario.CorreoElectronico}" +
                        $" contenido = {item.Contenido} ");
                }
                ; break;
            }
        default:
            break;
    }
}

Console.ReadKey();
