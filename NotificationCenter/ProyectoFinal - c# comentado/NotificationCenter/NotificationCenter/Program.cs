using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

using Amazon.Pinpoint;

namespace NotificationCenter
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new panelAdministracion());




            //List<string> tokens = new List<string>();
            //tokens.Add("cyr2e8EE4hE:APA91bGq5HAB1ctF8TAY-Naa1fnNY9ukPHHDqXI8JD19vkCwfIPOAb1S9o4k4mdQYy06jL5rzx3iNgnMNRIz0d0BypYRQ0mLnA3gFzZY1W5sQ8HuCt-THoCdhpNBruKd6tcaj8qQQN9F");
            //tokens.Add("d_exD6-OwSo:APA91bEGpUoj1FczqOe95tchnFUI_-VvifIen8-K2cz-fuNzSaZGvb10VlUYIzs1VQA8VpkFCtI1jpuwvtyzKfv6_owBN7JzksMfY8-reWiQEOLHAX98w3uYq1eJqXHgvya-jSVDoYco");

            //string titulo = "Reunion";
            //string cuerpo = "Hay que reunirse";

            //Enviador enviar = new Enviador();
            //enviar.Enviar(titulo, cuerpo, tokens);


        }
    }
}
