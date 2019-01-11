using System.Collections.Generic;
using Amazon;
using Amazon.Pinpoint;
using Amazon.Pinpoint.Model;
using Amazon.Runtime;

namespace NotificationCenter
{
    public class Enviador
    {
        public void Enviar(string tituloMensaje, string cuerpoMensaje, List<string> tokensUsuarios)
        {
            // Credenciales de AWS Amplify
            var credenciales = new BasicAWSCredentials("AKIAIZEF5WTFDM6DM5AQ", "OUprLHZcKKpw74iD3rgFSgGItA0H3BJZPeRAGba9");
            

            //Cliente de PinPoint para el envio de los mensajes
            var clientePinPoint = new AmazonPinpointClient(credenciales, RegionEndpoint.EUWest1);


            //Objeto que se utilizara para enviar el mensaje con el Metodo SendMessage
            var mensaje = new SendMessagesRequest();
            mensaje.ApplicationId = "ec46b55e911e404d98c5e8f1f32199d9";


            //Para entregar Notificaciones Push a terminales Android hacemos uso de Google Cloud Messaging 
            ChannelType tipoMensaje = Amazon.Pinpoint.ChannelType.GCM;


            //Configuracion para el envio de mensaje
            var configuracionAdress = new AddressConfiguration();
            configuracionAdress.ChannelType = tipoMensaje;


            //Al diccionario creado se le introducen los Tokens recibidos y el objeto de configuración
            var dict = new Dictionary<string, AddressConfiguration>();
            tokensUsuarios.ForEach(c => { dict.Add(c, configuracionAdress); });

            /*
             * directMessage es la definición del mensaje, mientras que configuracionGCM es el mensaje en sí.
             * Posteriormente se modifican propiedades del mensaje GCM y se concatena lo que queremos como mensaje
             * */
            var directMessage = new DirectMessageConfiguration();
            var configuracionGCM = new GCMMessage();

            configuracionGCM.TimeToLive = 500;
            configuracionGCM.SilentPush = true;
            configuracionGCM.Priority = "High";
            configuracionGCM.Body = "Reunion ahora a las 13:00 en sala de conferencias";
            configuracionGCM.Action = Amazon.Pinpoint.Action.OPEN_APP;
            configuracionGCM.Title = "Reunion inmediata";
            configuracionGCM.RawContent = "{\"data\":{\"title\":\"" + tituloMensaje + "\",\"body\":\"" + cuerpoMensaje + "\",\"url\":\"https://bettercaring.com.au\"}}";

            directMessage.GCMMessage = configuracionGCM;
            

            var request = new MessageRequest();

            request.Addresses = dict;
            request.MessageConfiguration = directMessage;

            mensaje.MessageRequest = request;

            clientePinPoint.SendMessages(mensaje);

        }

    }
}