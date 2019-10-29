using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DbUtility
{
    static class Program
    {
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool SetForegroundWindow(IntPtr hWnd);

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            bool mutexCreated = true;
            using (Mutex mutex = new Mutex(true, "DbUtility", out mutexCreated))
            {
                if (mutexCreated)
                {
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    DevExpress.Skins.SkinManager.EnableFormSkins();
                    DevExpress.Skins.SkinManager.EnableMdiFormSkins();

                    frmLogin loging = new frmLogin();
                    Application.Run(loging);

                    if (loging.UserName != null)
                    {

                        Application.Run(new frmDbUtility() { UserName = loging.UserName });
                    }
                }
                else
                {
                    Process current = Process.GetCurrentProcess();
                    foreach (Process process in Process.GetProcessesByName(current.ProcessName))
                    {
                        if (process.Id != current.Id)
                        {
                            DbUtilityHelper.DisplayMessageBox("Another instance of DB Utility is already running.", "information");
                            //XtraMessageBox.Show("Another instance of DB Utility is already running.", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            break;
                        }
                    }
                }
            }
        }


        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        //[STAThread]
        //static void Main()
        //{
        //    Application.EnableVisualStyles();
        //    Application.SetCompatibleTextRenderingDefault(false);
        //    Application.Run(new frmBackupSetting());
        //}
    }
}
