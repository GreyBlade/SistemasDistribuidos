using DivisaSolution.DataAccess;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DivisaSolution.IntegrationTests
{
    //[TestFixture]
    public class DivisaServiceTest
    {
        [Test]
        public void EUR_Exist()
        {
            DivisaSolution.Service.DivisaService servicio = new Service.DivisaService();
            Assert.AreEqual(servicio.DivisaExist("EUR"), "0.801093");
            //Assert USD to EUR rate is 0.801093
        }

        [Test]
        public void XXX_DoNotExist()
        {
            DivisaSolution.Service.DivisaService servicio = new Service.DivisaService();
            Assert.AreEqual("-1", servicio.DivisaExist("SLV"));
            //Assert USD to SLV rate is -1
        }
        [Test]
        public void XmlReaderTest()
        {
            XmlFileRepository reader = new XmlFileRepository();
            Assert.IsTrue(reader.GetAllCurrencies().Count > 0);
        }
    }
}
