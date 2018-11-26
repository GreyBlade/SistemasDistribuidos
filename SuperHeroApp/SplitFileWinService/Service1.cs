using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using StructureMap;
using SuperHeroesService;

namespace SplitFileWinService
{
    public partial class Service1 : ServiceBase
    {
        private static  StructureMap.Container _container = new StructureMap.Container(c => { c.AddRegistry<SuperHeroesService.Boostrap>(); });
        private System.Timers.Timer _timer = null;
        private System.Timers.Timer _timerOnceDay = null;


        public Service1()
        {
            _timer = new System.Timers.Timer();
            _timer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            _timer.Interval = 60000;
            _timer.Enabled = true;
            _timer.Start();
            System.Diagnostics.Debugger.Launch();
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            
        }

        protected override void OnStop()
        {
            _timer.Enabled = false;
            _timer.Dispose();
        }

        private static void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            var service = _container.GetInstance<ISuperHeroesService>();
        }
    }
}
