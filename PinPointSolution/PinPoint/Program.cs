using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amazon;
using Amazon.Pinpoint;
using Amazon.Pinpoint.Model;
using Amazon.Runtime;

namespace PinPoint
{
    class Program
    {
        static void Main(string[] args)
        {

            List<string> tokens = new List<string>();
            tokens.Add("cyr2e8EE4hE:APA91bGq5HAB1ctF8TAY-Naa1fnNY9ukPHHDqXI8JD19vkCwfIPOAb1S9o4k4mdQYy06jL5rzx3iNgnMNRIz0d0BypYRQ0mLnA3gFzZY1W5sQ8HuCt-THoCdhpNBruKd6tcaj8qQQN9F");
            tokens.Add("d_exD6-OwSo:APA91bEGpUoj1FczqOe95tchnFUI_-VvifIen8-K2cz-fuNzSaZGvb10VlUYIzs1VQA8VpkFCtI1jpuwvtyzKfv6_owBN7JzksMfY8-reWiQEOLHAX98w3uYq1eJqXHgvya-jSVDoYco");

            string titulo = "Reunion";
            string cuerpo = "Hay que reunirse";

            Enviador enviar = new Enviador();
            enviar.Enviar(titulo, cuerpo, tokens);

        }
    }
}
