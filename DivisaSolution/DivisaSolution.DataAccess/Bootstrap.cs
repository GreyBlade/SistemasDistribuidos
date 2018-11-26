using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DivisaSolution.DataAccess
{
    public class Bootstrap : Registry
    {
        public Bootstrap()
        {
            For<IRepository>().Use<XmlFileRepository>();
        }
    }
}
