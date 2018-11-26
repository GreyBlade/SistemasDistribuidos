using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    [DataContract]
    public class SuperHeroes
    {
        public string _nombre;
        public SuperHeroes(string nombre)
        {
            _nombre = nombre;
        }
    }
}
