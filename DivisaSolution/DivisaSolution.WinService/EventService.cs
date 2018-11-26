using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using StructureMap;

namespace DivisaSolution.WinService
{
    public partial class EventService : ServiceBase
    {
        public StructureMap.Container _container = new StructureMap.Container(c => { c.AddRegistry<DivisaSolution.Service.Bootstrap>(); });
        public delegate void OnPrintHandler(string mensaje);

        public EventService()
        {
            InitializeComponent();
        }

        public static void OnPrint(string mensaje)
        {
            Console.Out.WriteLine(mensaje);
        }

        protected override void OnStart(string[] args)
        {

            OnPrintHandler printHandler = OnPrint;
            printHandler("Este es un mensaje");
        }

        protected override void OnStop()
        {
            OnStart(null);
        }
    }
}
