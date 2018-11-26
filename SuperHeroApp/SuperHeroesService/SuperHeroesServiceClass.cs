using DataAccess;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;

namespace SuperHeroesService
{
    public class SuperHeroesServiceClass : ISuperHeroesService
    {
        private IDataRepository _repo = null;
        private string _hearoesPath = WebConfigurationManager.AppSettings["hereoPath"];
        private string _villainsPath = WebConfigurationManager.AppSettings["villainsPath"];
        private string _persons = WebConfigurationManager.AppSettings["superheoresfile"];
        private string _rule = WebConfigurationManager.AppSettings["ruletosplit"];

        public SuperHeroesServiceClass(IDataRepository repo)
        {
            _repo = repo;
        }


        public IList<SuperHeroes> GetHeroes()
        {
            var data = _repo.GetData(_hearoesPath);
            IList<SuperHeroes> heroes = new List<SuperHeroes>();
            foreach (var nombre in data)
            {
              heroes.Add(new SuperHeroes(nombre));   
            }
            return heroes;
        }

        public IList<Villains> GetVillains()
        {
            var villanos = _repo.GetData(_villainsPath);
            return villanos.Select(x => new Villains { Nombre = x }).ToList();
        }

        /*public IList<string> getDataOfFile()
        {
            IList<string> data = new List<string>();
            data = this.reader.GetData("C:\\Users\\Jaime\\Desktop\\personas.txt");
            return data;
        }*/

        public void splitFiles()
        {

            var data = _repo.GetData(_persons);

            /* Splitting villains */
            var villanos = data.
                                Where(x => isVillain(x)).ToList();
            _repo.WriteData(_villainsPath, villanos);
            /* ***************** */



            /* Splitting heroes */
            var heroes = data.
                            Where(x => !isVillain(x)).ToList();
            _repo.WriteData(_hearoesPath, heroes);
            /* ************* */
        }
        private bool isVillain(string nombre)
        {
            return nombre.Contains('D');
        }

        
    }
}
