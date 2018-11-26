using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Entidades;

namespace ServicioWeb
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IService1" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IService1
    {

        [OperationContract(Name = "TestHeroesJSON")]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json)]
        IList<SuperHeroes> getHeroes();

        [OperationContract(Name = "TestVillanosJSON")]
        [WebInvoke(Method = "Get", ResponseFormat = WebMessageFormat.Json)]
        IList<Villanos> getVillanos();

        // TODO: agregue aquí sus operaciones de servicio
    }


    // Utilice un contrato de datos, como se ilustra en el ejemplo siguiente, para agregar tipos compuestos a las operaciones de servicio.   
}
