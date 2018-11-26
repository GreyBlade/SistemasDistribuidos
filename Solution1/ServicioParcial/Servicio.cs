using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;
using Entidades;
using DataAccess;

namespace ServicioParcial
{
    public class Servicio : IServicio
    {

        private string personas = WebConfigurationManager.AppSettings["personas"];
        private string heroes = WebConfigurationManager.AppSettings["heroes"];
        private string villanos = WebConfigurationManager.AppSettings["villanos"];

   

        public void DivirArchivo()
        {
            var dataAccess = new AccesoDatos();
            var persons = dataAccess.Leer(personas);

            var hero = persons.Where(c => c.Contains('a')).ToList();
            var vill = persons.Where(c => !c.Contains('a')).ToList();

            dataAccess.Escribir(heroes, hero);
            dataAccess.Escribir(villanos, vill);


        }

        public IList<SuperHeroes> getSuper()
        {
            var dataAccess = new AccesoDatos();


            var hero = dataAccess.Leer(heroes);
   
            return  hero.Select(c => new SuperHeroes { Nombre = c }).ToList();
        }

        public IList<Villanos> getVillanos()
        {
            var dataAccess = new AccesoDatos();

            return dataAccess.Leer(villanos).Select(c => new Villanos { Nombre = c }).ToList();
        }
    }
}
