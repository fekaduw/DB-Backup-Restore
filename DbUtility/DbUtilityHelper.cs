using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DbUtility
{
    public class DbUtilityHelper
    {
        public static void DisplayMessageBox(string text, string type)
        {
            switch (type.ToLower())
            {
                case "error":
                    XtraMessageBox.Show(text, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;

                case "warning":
                    XtraMessageBox.Show(text, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;

                case "information":
                    XtraMessageBox.Show(text, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
            }
        }
    }

    public sealed class Singleton
    {
        public static Singleton Instance { get; private set; }

        private Singleton() { }

        public UISetting UISettings;

        static Singleton() { Instance = new Singleton(); }

    }
}
