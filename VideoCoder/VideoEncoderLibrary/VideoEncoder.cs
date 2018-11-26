using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoEncoderLibrary
{
    public class VideoEncoder
    {
        // Definir un evento
        // Definir un delegado y handler
        // Disparar el evento



        //Tarea: Subscritores multithread
        /*
            Cada subscritor lanzara hilos para hacer algo.
            Task, Parallel

            Cuenta bancaria, globalmente accesible por todo el proceso (static)
            Clase account, variable publica (public static int Balance) inicialmente 100
            {
            Publisher

            Clase accountManager metodos-> Credit(int amount +suma), Debit(int amount -resta) , event, delegate
            condicion el Balance es menor que 0 llamare un evento -> BancaRota
            }

            {
            Subscribers

            Clase EmailBankRuptService List<String> emails-> mandara correo electronico a personas que esten en bancarota 
            usar ParallelForEach()

            SendEmail() -> Debe enviar un email real

            Clase DBBankRuptService 
            handler que haga console.writeline que indique se guardo a bd
            }
        */
        public delegate void VideoEncoderEventHandler(object sender, int money);
        

        public event VideoEncoderEventHandler OnVideoEncoded;

        public void Encode(Video video)
        {
            Console.WriteLine("Video encoding in process");
            Codificado();


        }

        protected void Codificado()
        {
            if (OnVideoEncoded != null)
                OnVideoEncoded(this,500);
        }
    }
}
