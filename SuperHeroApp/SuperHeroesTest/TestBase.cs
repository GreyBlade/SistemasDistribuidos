using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StructureMap;

namespace SuperHeroesTest
{
    public class TestBase
    {
        public Container container = new Container(c => { c.AddRegistry<SuperHeroesService.Boostrap>(); });
    }
}
