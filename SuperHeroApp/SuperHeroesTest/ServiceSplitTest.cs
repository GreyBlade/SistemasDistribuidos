using DataAccess;
using SuperHeroesService;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StructureMap;

namespace SuperHeroesTest
{
    class ServiceSplitTest : TestBase
    {

        [Test]
        public void SuperHeroesService_SplitFilesTest()
        {
            var service = container.GetInstance<SuperHeroesServiceClass>();
            service.splitFiles();

            var listHeroes = service.GetHeroes();
            var listVillains = service.GetVillains();

            Assert.IsTrue(listHeroes.Count > 0);
            Assert.IsTrue(listVillains.Count > 0);

        }
    }
}
