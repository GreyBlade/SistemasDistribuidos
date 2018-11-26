using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace ServicioSuperHeroes
{
    [DataContract]
    public class SuperHeroesService : ISuperHeoresService
    {
        [DataMember]
        string nombre;

        public string GetHeroes(int value)
        {
            return "Hola";
        }

        public string GetVillanos()
        {
            return "adios";
        }
    }

}