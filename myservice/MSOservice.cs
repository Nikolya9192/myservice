using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Timers;

namespace MSOservice
{
    public partial class MSOservice : ServiceBase
    {
        Tasklist tasklist = new Tasklist();
        public MSOservice()
        {
            InitializeComponent();
            
            if (!System.Diagnostics.EventLog.SourceExists("MySource"))
            {
                System.Diagnostics.EventLog.CreateEventSource(
                    "MySource", "MyNewLog");
            }
            eventLog1.Source = "MySource";
            eventLog1.Log = "MyNewLog";
        }

        Timer timer;
        protected override void OnStart(string[] args)
        {
            eventLog1.WriteEntry("In OnStart");
            
            timer = new Timer();
            timer.Interval = 1000;           
            timer.Elapsed += new ElapsedEventHandler(timer_Elapsed);
            timer.Start();
            
        }

        void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            tasklist.KillRunningProcesses();
        }

        protected override void OnStop()
        {
            eventLog1.WriteEntry("In onStop.");
            timer.Stop();
        }
        
        protected override void OnContinue()
        {
            eventLog1.WriteEntry("In OnContinue.");
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }  
    }
}
