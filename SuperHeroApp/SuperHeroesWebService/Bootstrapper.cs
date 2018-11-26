using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataAccess;
using StructureMap;
using SuperHeroesService;

namespace SuperHeroesWebService
{
    public class Bootstrapper : Registry
    {
        public Bootstrapper()
        {
            For<IDataRepository>().Use<FileDataRepository>();
            For<ISuperHeroesService>().Use<SuperHeroesServiceClass>();
            For<IService1>().Use<Service1>();
        }
    }
}