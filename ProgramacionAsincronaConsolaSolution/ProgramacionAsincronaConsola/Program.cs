using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;

namespace ProgramacionAsincronaConsola
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Empezando programa");
            DownloadAsync();
            Console.WriteLine("Esperando");
            Console.ReadKey();

        }

        static private async void DownloadAsync()
        {
            HttpClient httpClient = new HttpClient();
            var mensaje = await httpClient.PostAsync("https://httpbin.org/post", null);
            Console.WriteLine(mensaje);
        }
    }
}
