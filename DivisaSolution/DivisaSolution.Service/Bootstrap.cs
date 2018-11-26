using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StructureMap;

namespace DivisaSolution.Service
{
    public class Bootstrap : Registry
    {
        public Bootstrap()
        {
            For<IDivisaService>().Use<DivisaService>();
        }
    }
}
