using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraSplashScreen;

namespace DbUtility
{
    public partial class SplashScreen1 : SplashScreen
    {
        public SplashScreen1()
        {
            InitializeComponent();

            lblCopyright.Text = String.Format("Copyright © 2009 - {0}" ,DateTime.Now.Year.ToString());

            SettingBL settingBL = new SettingBL();
            UISetting uiSetting = new UISetting();
            uiSetting = settingBL.GetUISetting();
            if (uiSetting != null)
            {
                Singleton.Instance.UISettings = uiSetting;
                DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle(Singleton.Instance.UISettings.Name);
            }
        }

        #region Overrides

        public override void ProcessCommand(Enum cmd, object arg)
        {
            base.ProcessCommand(cmd, arg);
        }

        #endregion

        public enum SplashScreenCommand
        {
        }
    }
}