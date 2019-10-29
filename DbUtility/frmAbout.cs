using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace DbUtility
{
    public partial class frmAbout : DevExpress.XtraEditors.XtraForm
    {
        public frmAbout()
        {
            InitializeComponent();

            PopulateData();
        }

        private void PopulateData()
        {
           lblVersion.Text = Application.ProductVersion;

           int startYear = 2014;
           string copyright = DateTime.Now.Year == startYear ? DateTime.Now.Year.ToString() : string.Format("2014 - {0}", DateTime.Now.Year);
           lblCopyright.Text = String.Format("Copyright © {0}. \nJSI Research && Training Institute, Inc. HMIS Scale up Project", copyright);
        }
    }
}