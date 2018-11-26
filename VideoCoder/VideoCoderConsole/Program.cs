using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoEncoderLibrary;

namespace VideoCoderConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            List<String> emails = new List<String> { "1", "2", "3" };
            var video = new Video() { Title = "Test"};
            video.Title = "Mi video";
            var encoder = new VideoEncoder();
            var mailService = new MailService();
            var chargeService = new ChargeService();
            //encoder.OnVideoEncoded += mailService.HandlerEvento;
            encoder.OnVideoEncoded += chargeService.Charge;

            //Parallel.ForEach(emails,
              //  new ParallelOptions { MaxDegreeOfParallelism=2},
                //x => Test(x));
            //encoder.Encode(video);



            
        }
        public static void Test(string email)
        {
            Console.WriteLine("Enviando correo a " + email);
            System.Threading.Thread.Sleep(5000);
            Console.WriteLine("Correo enviado a " + email);
        }

        public class MailService
        {public void HandlerEvento(object sender)
            {
                Console.WriteLine("Manejador del evento, mandado mail");
            }
        }

        public class ChargeService
        {
            public void Charge(object sender, int money)
            {
                Console.WriteLine("Cargado" + money);
                System.Threading.Thread.Sleep(5000);
            }
        }
    }
}
