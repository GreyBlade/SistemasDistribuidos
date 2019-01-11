using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amazon;
using Amazon.Pinpoint;
using Amazon.Pinpoint.Model;
using Amazon.Runtime;

namespace PinPoint
{
    public class Enviador
    {
        public void Enviar(string titulo, string cuerpo, List<string> tokens)
        {
            // Credenciales para Amazon (usando las de Amplify)
            var credentials = new BasicAWSCredentials("AKIAIZEF5WTFDM6DM5AQ", "OUprLHZcKKpw74iD3rgFSgGItA0H3BJZPeRAGba9");
            //Cliente de pinpoint para enviar el mensaje
            var a = new AmazonPinpointClient(credentials, RegionEndpoint.EUWest1);

            //Objeto que se utilizara para enviar el mensaje con el Metodo SendMessage
            var mensaje = new SendMessagesRequest();
            mensaje.ApplicationId = "ec46b55e911e404d98c5e8f1f32199d9";
            //--------------------------------------------------------

            //Contexto, serian los valores a enviar a la notificacion
            var context = new Dictionary<string, string>();
            context.Add("Titulo", "Reunion");
            context.Add("Cuerpo", "Asistir");
            //------------------------------------------------


            //Canal que se utilizara para enviar el mensaje
            //Configuraciones para el envio del mensaje
            ChannelType canal = Amazon.Pinpoint.ChannelType.GCM;
            var request = new MessageRequest();

            var configuracionAdress = new AddressConfiguration();
            configuracionAdress.ChannelType = canal;
            configuracionAdress.Context = context;

            var dict = new Dictionary<string, AddressConfiguration>();

            tokens.ForEach(c => { dict.Add(c, configuracionAdress); });
            //dict.Add("d_exD6-OwSo:APA91bEGpUoj1FczqOe95tchnFUI_-VvifIen8-K2cz-fuNzSaZGvb10VlUYIzs1VQA8VpkFCtI1jpuwvtyzKfv6_owBN7JzksMfY8-reWiQEOLHAX98w3uYq1eJqXHgvya-jSVDoYco", configuracionAdress);
            //-------------------------------------------------


            //Configuracion para enviar mensaje GCM
            var directMessage = new DirectMessageConfiguration();
            var configuracionGCM = new GCMMessage();
            configuracionGCM.TimeToLive = 500;
            configuracionGCM.SilentPush = true;
            configuracionGCM.Priority = "High";
            configuracionGCM.Body = "Reunion ahora a las 13:00 en sala de conferencias";
            configuracionGCM.Action = Amazon.Pinpoint.Action.OPEN_APP;
            configuracionGCM.Title = "Reunion inmediata";
            configuracionGCM.RawContent = "{\"data\":{\"title\":\"" + titulo + "\",\"body\":\""+cuerpo+"\",\"url\":\"https://bettercaring.com.au\"}}";

            directMessage.GCMMessage = configuracionGCM;



            //Objeto de tipo EndPointConfiguration
            var endpoint = new Dictionary<string, EndpointSendConfiguration>();
            endpoint.Add("cyr2e8EE4hE:APA91bGq5HAB1ctF8TAY-Naa1fnNY9ukPHHDqXI8JD19vkCwfIPOAb1S9o4k4mdQYy06jL5rzx3iNgnMNRIz0d0BypYRQ0mLnA3gFzZY1W5sQ8HuCt-THoCdhpNBruKd6tcaj8qQQN9F",
                new EndpointSendConfiguration());

            /* ---------------------------------------- */





            //Llenando propiedades de MessageRequest
            request.Addresses = dict;
            request.Context = context;
            //request.Endpoints = endpoint;
            request.MessageConfiguration = directMessage;



            //  mensaje.
            //ensaje
            mensaje.MessageRequest = request;
            a.SendMessages(mensaje);

        }

    }
}
