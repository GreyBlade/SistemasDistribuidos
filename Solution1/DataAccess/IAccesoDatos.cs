using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public interface IAccesoDatos
    {
        void Escribir(string ruta, IList<string> personas);
        IList<string> Leer(string ruta);

    }
}
