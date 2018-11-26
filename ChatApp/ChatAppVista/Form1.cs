using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChatAppVista
{
    [ServiceBehavior(InstanceContextMode=InstanceContextMode.Single)]
    public partial class Form1 : Form, IQuickReturnTraderChat
    {
        IQuickReturnTraderChat channel;
        ServiceHost host = null;
        ChannelFactory<IQuickReturnTraderChat> channelFactory = null;
        string userID = "Jaime Cuellar";

        public Form1()
        {
            InitializeComponent();
            StartService();
        }

        public void Say(string user, string message)
        {
            this.richTextChat.Text += user + " dice: " + message + Environment.NewLine;
        }

        private void StartService()
        {
            //Se crea el servicio de host
            host = new ServiceHost(this);
            //Se abre el servicio
            host.Open();

            channelFactory = new ChannelFactory<IQuickReturnTraderChat>("QuickTraderChatEndpoint");

            channel = channelFactory.CreateChannel();

            channel.Say("Admin", "El usuario: " + userID + " se ha unido al canal" + Environment.NewLine);
        }

        private void StopService()
        {

        }

        private void buttonSend_Click(object sender, EventArgs e)
        {
            this.channel.Say(userID, this.textBoxMessage.Text + "\n");
            //this.richTextChat.AppendText(this.textBoxMessage.Text+"\n");
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            StopService();
        }

        private void textBoxMessage_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                this.channel.Say(userID, this.textBoxMessage.Text + "\n");
                //this.richTextChat.AppendText(this.textBoxMessage.Text + "\n");
                this.textBoxMessage.Text = "";
            }
        }
    }
}
