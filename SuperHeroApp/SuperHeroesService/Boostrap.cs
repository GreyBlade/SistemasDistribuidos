using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using StructureMap;

namespace SuperHeroesService
{
    public class Boostrap : Registry
    {


        public Boostrap()
        {
            For<IDataRepository>().Use<FileDataRepository>();
            For<ISuperHeroesService>().Use<SuperHeroesServiceClass>();
        }
    }
}
