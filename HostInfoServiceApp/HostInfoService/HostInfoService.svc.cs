using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace HostInfoService
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código, en svc y en el archivo de configuración.
    // NOTE: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Service1.svc o Service1.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class HostInfoService : IHostInfoService
    {
       

        public HostInfo GetData(bool condicion)
        {
            return new HostInfo
            {
                HostName = condicion ? System.Environment.MachineName: " ",
                ip = Dns.GetHostEntry(Dns.GetHostName())
                           .AddressList.First(
                                   f => f.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                                   .ToString(),
                OsVersion = Environment.OSVersion.VersionString
            };
        }
    }
}
