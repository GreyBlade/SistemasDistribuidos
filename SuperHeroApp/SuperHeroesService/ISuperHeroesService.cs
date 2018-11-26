using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperHeroesService
{
    public interface ISuperHeroesService
    {
       // IList<string> getDataOfFile();
        IList<SuperHeroes> GetHeroes();
        IList<Villains> GetVillains();
        void splitFiles();
    }
}
