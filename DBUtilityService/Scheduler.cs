using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace DBUtilityService
{
    class Scheduler
    {
        private System.Timers.Timer oTimer =null;
        private int interval = 20000;


        public void Start()
        {
            oTimer = new System.Timers.Timer(interval);
            oTimer.AutoReset = true;
            oTimer.Enabled = true;
            oTimer.Start();
            oTimer.Elapsed += new System.Timers.ElapsedEventHandler(Timer_Elapsed);
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            DatabaseBackup oDatabaseBackup = new DatabaseBackup();
            oDatabaseBackup.Start();

        }
    }
}
