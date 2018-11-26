using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace ServicioParcial
{
    interface IServicio
    {
        void DivirArchivo();
        IList<SuperHeroes> getSuper();
        IList<Villanos> getVillanos();
    }
}
