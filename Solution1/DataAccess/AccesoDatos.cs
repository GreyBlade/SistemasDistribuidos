using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class AccesoDatos : IAccesoDatos
    {
        public void Escribir(string ruta, IList<string> personas)
        {
            File.WriteAllLines(ruta, personas);
        }

        public IList<string> Leer(string ruta)
        {
            return File.ReadAllLines(ruta).ToList();
        }
    }
}
