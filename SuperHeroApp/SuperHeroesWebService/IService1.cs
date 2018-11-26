using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Entities;

namespace SuperHeroesWebService
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IService1" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        IList<string> Test();
        // TODO: agregue aquí sus operaciones de servicio
        
        [OperationContract]
        IList<SuperHeroes> heores();

        [OperationContract]
        IList<Villains> villanos();
    }
}
