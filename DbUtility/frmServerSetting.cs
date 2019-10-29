using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;

namespace DbUtility
{
    public partial class frmServerSetting : DevExpress.XtraEditors.XtraForm
    {
        SettingBL oSettingBL;
        ServerSetting oServerSettingBL;
        DbUtilityBL oDbUtilityBL;

        public frmServerSetting()
        {
            InitializeComponent();
            oDbUtilityBL = new DbUtilityBL();
            oSettingBL = new SettingBL();
            oServerSettingBL = new ServerSetting();

            PopulateServers();

            PopulateData();
        }

        private void PopulateData()
        {
            try
            {
                oServerSettingBL = oSettingBL.GetServerSetting();
                if(oServerSettingBL !=null)
                {
                    lkeServer.EditValue = oServerSettingBL.Name;
                    txtUserName.Text = oServerSettingBL.UserName;
                    txtPassword.Text = oServerSettingBL.Password;
                    lkeDatabase.EditValue = oServerSettingBL.Database;
                }
            }
            catch (Exception ex)
            {
                DbUtilityHelper.DisplayMessageBox(ex.Message, "error");
            }
        }

        /// <summary>
        /// Populates the SQL Server instance names
        /// </summary>
        public void PopulateServers()
        {
            try
            {
                SplashScreenManager.ShowForm(typeof(WaitForm1));

                lkeServer.Properties.DataSource = oDbUtilityBL.GetServers();

                SplashScreenManager.CloseForm();
            }
            catch (Exception ex)
            {
                DbUtilityHelper.DisplayMessageBox(ex.Message, "error");
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (lkeServer.EditValue != null && lkeDatabase.EditValue != null && !String.IsNullOrEmpty(txtUserName.Text) && !String.IsNullOrEmpty(txtPassword.Text))
                {
                    oServerSettingBL = new ServerSetting()
                    {
                        Name = lkeServer.EditValue.ToString(),
                        UserName = txtUserName.Text.Trim(),
                        Password = EncryptDecrypt.Encrypt(txtPassword.Text.Trim(), "123"),
                        Database = lkeDatabase.EditValue.ToString()
                    };

                    if (oSettingBL.Add(oServerSettingBL))
                        DbUtilityHelper.DisplayMessageBox("Server setting successfully saved", "information");
                    else
                        DbUtilityHelper.DisplayMessageBox("Server setting could not be saved. Please try agin!", "error");
                }
                else
                    DbUtilityHelper.DisplayMessageBox("Required fields can not be blank.", "warning");
            }
            catch (Exception ex)
            {
                DbUtilityHelper.DisplayMessageBox(ex.Message, "error");
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                PopulateServers();
            }
            catch (Exception ex)
            {
                DbUtilityHelper.DisplayMessageBox("Server instances could not be loaded. Try again!\n" + ex.Message, "error"); 
            }
        }

        private void lkeServer_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                lkeDatabase.Properties.DataSource = oDbUtilityBL.GetDatabases(lkeServer.EditValue.ToString());
            }
            catch (Exception ex)
            {
                DbUtilityHelper.DisplayMessageBox("The system could not load databases. Try again\n" + ex.Message, "warning");
            }
        }
    }
}