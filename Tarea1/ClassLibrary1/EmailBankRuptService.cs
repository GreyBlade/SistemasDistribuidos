using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Subscribers
{
    public class EmailBankRuptService
    {

        public void SendEmailHandler()
        {
            Console.WriteLine("Mandar correo por bancarrota");
            List<String> correos = new List<string> { "jaime.cuellar@alumnos.uneatlantico.es"};
            System.Threading.Thread.Sleep(3000);
            Parallel.ForEach(correos, x => SendEmail(x));

        }

        public void SendEmail(String correo)
        {

            System.Threading.Thread.Sleep(2000);
            Console.WriteLine("Mandando email a " + correo);

            var credenciales = new NetworkCredential("jaime.cuellar@alumnos.uneatlantico.es", "B0PkhZbd");
            var mail = new MailMessage()
            {
                From = new MailAddress("jaime.cuellar@alumnos.uneatlantico.es"),
                Subject = "Test email.",
                Body = "Test email body"
            };
            mail.To.Add(new MailAddress(correo));
            var client = new SmtpClient()
            {
                Port = 587,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Host = "smtp.gmail.com",
                EnableSsl = true,
                Credentials = credenciales
            };
            client.Send(mail);


        }
    }
}
