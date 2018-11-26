using NUnit.Framework;
using ServiceClient.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceClient
{
    public class ServiceClientTest
    {
        [Test]
        public void TestServiceClient()
        {
            HostInfoServiceClient cliente = new HostInfoServiceClient();
            HostInfo resultado = cliente.GetData(true);
            Assert.AreEqual(resultado.HostName, "DESKTOP-37OFRPI");
        }
    }
}
