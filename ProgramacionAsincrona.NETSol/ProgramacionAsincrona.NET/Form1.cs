using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProgramacionAsincrona.NET
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSincrona_Click(object sender, EventArgs e)
        {
            RunSomethingSync();
        }

        private void btnAsincrona_Click(object sender, EventArgs e)
        {
            RunSomethingAsync();
            this.txtResult.Text = "Esperando metodo asincrono";
        }

        private async void RunSomethingAsync()
        {
            Task<String> task = new Task<String>(RunSomething);
            task.Start();

            this.txtResult.Text = await task;
            this.txtResult.Text = "Finalizo la tarea principal";

        }
        private void RunSomethingSync()
        {
            this.txtResult.Text = RunSomething();
            this.txtResult.Text = "Se termino la tarea principal";
        }

        private string RunSomething()
        {
            System.Threading.Thread.Sleep(5000);
            return "Se termino una tarea";
        }
    }
}
