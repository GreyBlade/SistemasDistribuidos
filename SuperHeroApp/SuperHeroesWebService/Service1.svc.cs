using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Entities;
using StructureMap;
using SuperHeroesService;

namespace SuperHeroesWebService
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código, en svc y en el archivo de configuración.
    // NOTE: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Service1.svc o Service1.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class Service1 : IService1
    {

        public Container container = new Container(c => { c.AddRegistry<SuperHeroesService.Boostrap>(); });

        public IList<SuperHeroes> heores()
        {
           return  container.GetInstance<SuperHeroesServiceClass>().GetHeroes().ToList();
        }

        public IList<string> Test()
        {
            throw new NotImplementedException();
        }

        public IList<Villains> villanos()
        {
            return container.GetInstance<SuperHeroesServiceClass>().GetVillains().ToList();
        }
    }
}
