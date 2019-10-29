using System;
using System.ComponentModel;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;
using System.Threading;
using System.Net.Mail;
using System.Net;
using DevExpress.LookAndFeel;
using DevExpress.XtraBars;
using DevExpress.Skins;
using System.Timers;
using System.Reflection;

namespace DbUtility
{
    
    public partial class frmDbUtility : DevExpress.XtraEditors.XtraForm
    {
        //creates DbUtilityBL object
        DbUtilityBL oDbUtilityBL;
        
        //holds the logged in name from the login screen
        public string UserName { get; set; }

        //if set to false, users will not be allowed to close the form (i.e. bakup or restore in progress)
        private bool canClose = true;

        //used to store the UI skin and other settings in UISetting.xml
        SettingBL settingBL;
        UISetting uiSetting;

        public BackgroundWorker worker;
    
        public frmDbUtility()
        {
           InitializeComponent();

            oDbUtilityBL = new DbUtilityBL();

            oDbUtilityBL.CurrentProgress = 0;
            oDbUtilityBL.HasError = false;

            settingBL = new SettingBL();
            uiSetting = new UISetting();

            //dbUtilityBL.OnProgressUpdate += dbUtility_OnProgressUpdate;
            UpdateCompletionStatus.OnNewCompletionStatus += dbUtility_OnProgressUpdate;

            barDevExpressStyle.Checked = true;

            Initialize();
        }

        #region Methods

        /// <summary>
        /// Initializes the application's default skin
        /// </summary>
        private void Initialize()
        {
            try
            {
                if (settingBL.GetUISetting() != null)
                {
                    DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle(Singleton.Instance.UISettings.Name);

                    //set checked status of the selected skin name
                    foreach (BarItem barItem in bar.Manager.Items)
                    {
                        if (barItem.GetType() == typeof(BarCheckItem))
                        {
                            if (barItem.Caption.Equals(Singleton.Instance.UISettings.Name))
                                ((BarCheckItem)barItem).Checked = true;
                        }
                    }
                }

                SetDefaultServerSettings();
            }catch(Exception ex)
            {
                DbUtilityHelper.DisplayMessageBox(ex.Message, "error");
            }
        }

        private void SetDefaultServerSettings()
        {
            try
            {
                PopulateServers();

                
                ServerSetting oServerSetting = settingBL.GetServerSetting();
                if (oServerSetting != null)
                {
                    lkeServer.EditValue = oServerSetting.Name;
                    
                    if (lkeServer.EditValue != null)
                    {
                        PopulateDatabases(lkeServer.EditValue.ToString());
                        lkeDatabases.EditValue = oServerSetting.Database;
                    }
                    
                    txtUserName.Text = oServerSetting.UserName;
                    txtPassword.Text = oServerSetting.Password;
                }
                else
                    DbUtilityHelper.DisplayMessageBox("Default server setting could not be loaded. Try again.", "warning");
            }
            catch (Exception ex)
            {
                DbUtilityHelper.DisplayMessageBox("Default server setting could not be loaded. Try again.\n"+ex.Message, "error");
            }
        }

        /// <summary>
        /// Sets the server's username and password if the logged in name is guest 
        /// </summary>
        private void IsUserGuest()
        {
            if (UserName!=null && UserName.ToLower().Equals("guest"))
            {
                if (!String.IsNullOrWhiteSpace(lkeDatabases.Text))
                {
                    chkWindowsAuthentication.CheckState = CheckState.Unchecked;
                    
                    oDbUtilityBL.UserName = "sa";
                    oDbUtilityBL.Password = oDbUtilityBL.GetServerPassword(lkeDatabases.Text);
                }

                txtUserName.Text = "xxxxxxxxxx";
                txtPassword.Text = "xxxxxxxxxx";

                chkWindowsAuthentication.Enabled = txtUserName.Enabled = txtPassword.Enabled = false;
            }
        }

        /// <summary>
        /// Options are populated based on the user login. Admin user name can have Backup/Restore option. 
        /// But, Guests can only take a backup
        /// </summary>
        private void PopulateOptions()
        {
            cboOption.Properties.Items.Clear();

            cboOption.Properties.Items.Add("Backup");
            cboOption.SelectedIndex = 0;

            if(UserName.ToLower().Equals("admin"))
            {
                cboOption.Properties.Items.Add("Restore");
                cboOption.SelectedIndex = 0;
            }
        }

        /// <summary>
        /// Populates the SQL Server instance names
        /// </summary>
        private void PopulateServers()
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

        /// <summary>
        /// Populates databases unders the selected server
        /// </summary>
        /// <param name="serverName"></param>
        private void PopulateDatabases(string serverName)
        {
            try
            {
                //SplashScreenManager.ShowForm(typeof(WaitForm1));

                if(!string.IsNullOrEmpty(serverName))
                    lkeDatabases.Properties.DataSource = oDbUtilityBL.GetDatabases(serverName);

                //SplashScreenManager.CloseForm();
            }
            catch (Exception ex)
            {
                DbUtilityHelper.DisplayMessageBox(ex.Message, "error");
            }

        }

        /// <summary>
        /// This method enables/disables form controls
        /// </summary>
        /// <param name="enableStatus">true/false</param>
        private void EnableControls(bool enableStatus)
        {
            try
            {
                if (UserName.ToLower().Equals("admin"))
                {
                    chkWindowsAuthentication.Invoke((MethodInvoker)(delegate()
                    {
                        chkWindowsAuthentication.Enabled = enableStatus;
                    }));

                    txtUserName.Invoke((MethodInvoker)(delegate()
                    {
                        txtUserName.Enabled = !chkWindowsAuthentication.Checked && enableStatus;
                    }));

                    txtPassword.Invoke((MethodInvoker)(delegate()
                    {
                        txtPassword.Enabled = !chkWindowsAuthentication.Checked && enableStatus;
                    }));
                }

                lkeServer.Invoke((MethodInvoker)(delegate()
                {
                    lkeServer.Enabled = enableStatus;
                }));


                cboOption.Invoke((MethodInvoker)(delegate()
                {
                    cboOption.Enabled = enableStatus;
                }));
                lkeDatabases.Invoke((MethodInvoker)(delegate()
                {
                    lkeDatabases.Enabled = enableStatus;
                }));
                btnSelectBackupFile.Invoke((MethodInvoker)(delegate()
                {
                    btnSelectBackupFile.Enabled = enableStatus;
                }));
                btnBackup.Invoke((MethodInvoker)(delegate()
                {
                    btnBackup.Enabled = enableStatus;
                }));
                btnBackupLocation.Invoke((MethodInvoker)(delegate()
                {
                    btnBackupLocation.Enabled = enableStatus;
                }));
                btnBackup.Invoke((MethodInvoker)(delegate()
                {
                    btnBackup.Enabled = enableStatus;
                }));

                btnRestore.Invoke((MethodInvoker)(delegate()
                {
                    btnRestore.Enabled = enableStatus;
                }));

                btnSync.Invoke((MethodInvoker)(delegate()
                {
                    btnSync.Enabled = enableStatus;
                }));

                barSetting.Enabled = barHelp.Enabled = enableStatus;
            }
            catch (Exception ex)
            {
                throw new TargetInvocationException(ex);
            }
        }

        /// <summary>
        /// Checks whether a form is already open before opening another instance of it
        /// </summary>
        /// <param name="frm"></param>
        /// <returns></returns>
        private bool IsAlreadyOpened(Form frm)
        {
            bool result = false;
            FormCollection openedForms = Application.OpenForms;
            //foreach (var f in openedForms)
            //{
            for(int c=0;c<openedForms.Count; c++)
            {
                if (openedForms[c].GetType() == frm.GetType())
                {
                    result = true;
                    openedForms[c].Activate();
                    if (openedForms[c].WindowState == FormWindowState.Minimized)
                        openedForms[c].WindowState = FormWindowState.Normal;
                    break;
                }
            }
            return result;
        }

        private bool RequiredFieldsNotBlank(string type)
        {
            try
            {
                if (lkeServer.EditValue == null)
                {
                    DbUtilityHelper.DisplayMessageBox("Please select the server before proceeding", "warning");
                    return false;
                }
                else if ((chkWindowsAuthentication.CheckState == CheckState.Unchecked && UserName.ToLower().Equals("admin")) && (String.IsNullOrWhiteSpace(txtUserName.Text) || String.IsNullOrWhiteSpace(txtPassword.Text)))
                {
                    DbUtilityHelper.DisplayMessageBox("User name and/or password can not be blank", "warning");

                    if (String.IsNullOrWhiteSpace(txtUserName.Text))
                        txtUserName.Focus();
                    else
                        txtPassword.Focus();

                    return false;
                }
                else if (lkeDatabases.EditValue == null)
                {
                    DbUtilityHelper.DisplayMessageBox("Please select the database", "warning");
                    return false;
                }

                if (type.ToLower().Equals("backup"))
                {
                    if (String.IsNullOrWhiteSpace(txtBackupLocation.Text))
                    {
                        DbUtilityHelper.DisplayMessageBox("Please select database backup location", "warning");
                        return false;
                    }
                }
                else //restore
                {
                    if (String.IsNullOrWhiteSpace(txtDBBackupFile.Text))
                    {
                        DbUtilityHelper.DisplayMessageBox("Please select the database backup file", "warning");
                        return false;
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        #endregion

        #region Event Handlers

        private void btnSelectDBFile_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog _dlg = new OpenFileDialog();
                _dlg.Filter = "Files to Extract |*.bak;*.zip";
                _dlg.ShowDialog();
                
                if (!String.IsNullOrWhiteSpace(_dlg.FileName))
                    txtDBBackupFile.Text = _dlg.FileName;
            }
            catch (Exception ex)
            {
                DbUtilityHelper.DisplayMessageBox("Some error > " + ex.Message, "Error");
            }
        }

        private void chkWindowsAuthentication_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                txtUserName.Enabled = txtPassword.Enabled = !chkWindowsAuthentication.Checked;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Some error occurred! " + ex.Message);
            }
        }

        private void btnBackup_Click(object sender, EventArgs e)
        {
            try
            {
                prgBarDbUtility.Text = (0).ToString();

                if (RequiredFieldsNotBlank("backup"))
                {
                    oDbUtilityBL.DbName = lkeDatabases.EditValue.ToString().Trim();
                    oDbUtilityBL.DbBackupLocation = txtBackupLocation.Text.Trim();
                    oDbUtilityBL.TaskIsBackup = true;

                    if (chkWindowsAuthentication.CheckState == CheckState.Unchecked)
                    {
                        oDbUtilityBL.UserName = txtUserName.Text.Trim();
                        oDbUtilityBL.Password = txtPassword.Text.Trim();
                    }

                    //users are not allowed to close the form
                    canClose = false;

                    oDbUtilityBL.IsLoginSecured = chkWindowsAuthentication.CheckState == CheckState.Unchecked ? false : true;

                    oDbUtilityBL.ServerName = lkeServer.EditValue.ToString();

                    oDbUtilityBL.Connect();

                    SplashScreenManager.ShowForm(typeof(WaitForm1));

                    backgroundWorker.RunWorkerAsync();
                }
            }
            catch (Exception ex)
            {
                DbUtilityHelper.DisplayMessageBox(ex.Message, "error");
            }
        }

        private void btnRestore_Click(object sender, EventArgs e)
        {
            try
            {
                prgBarDbUtility.Text = (0).ToString();

                if (RequiredFieldsNotBlank("restore"))
                {
                    oDbUtilityBL.DbName = txtDatabase.Text.Trim();//lkeDatabases.EditValue.ToString().Trim();
                    oDbUtilityBL.FilePath = txtDBBackupFile.Text.Trim();
                    oDbUtilityBL.TaskIsBackup = false;
                    if (chkWindowsAuthentication.CheckState == CheckState.Unchecked)
                    {
                        oDbUtilityBL.UserName = txtUserName.Text.Trim();
                        oDbUtilityBL.Password = txtPassword.Text.Trim();
                    }

                    //users are not allowed to close the form
                    canClose = false;

                    oDbUtilityBL.IsLoginSecured = chkWindowsAuthentication.CheckState == CheckState.Unchecked ? false : true;

                    oDbUtilityBL.ServerName = lkeServer.EditValue.ToString();

                    oDbUtilityBL.Connect();

                    SplashScreenManager.ShowForm(typeof(WaitForm1));

                    backgroundWorker.RunWorkerAsync();
                }
            }
            catch (Exception ex)
            {
                DbUtilityHelper.DisplayMessageBox(ex.Message, "Error");
            }
        }

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                EnableControls(false);

                barStatus.Caption = string.Empty;

                if (cboOption.SelectedIndex == 0)
                {
                    oDbUtilityBL.BackupDatabase();
                    oDbUtilityBL.CompressDbBackup();
                }
                else
                {
                    //oDbUtilityBL.ExtractZipFile();
                    oDbUtilityBL.RestoreDatabase();
                }
            }
            catch (Exception ex)
            {
                throw new TargetInvocationException(ex);
            }
        }

        public void dbUtility_OnProgressUpdate(int value, string status)
        {
            try
            {
                if (InvokeRequired)
                {
                    Invoke(new Action<int, string>(dbUtility_OnProgressUpdate), value, status);
                    return;
                }


                prgBarDbUtility.Text = Convert.ToString(value);
                barStatus.Caption = status;
            }
            catch (Exception ex)
            {
                throw new TargetInvocationException(ex);
            }
        }

        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            string _message;
            string _caption;

            SplashScreenManager.CloseForm();

            if (oDbUtilityBL.IsCompleted)
            {
                _message = cboOption.SelectedIndex == 1 ? "Database restore successfully completed" : "Database backup successfully completed";
                _caption = cboOption.SelectedIndex == 1 ? "Database Restore" : "Database Backup";

                barStatus.Caption = _message;

                DbUtilityHelper.DisplayMessageBox(_message, "information");
            }
            else
                DbUtilityHelper.DisplayMessageBox("Sorry database " + cboOption.Properties.Items[cboOption.SelectedIndex].ToString().ToLower() + " could not be completed", "error");

            canClose = true;

            EnableControls(true);
        }

        private void frmDbUtility_Load(object sender, EventArgs e)
        {
            lblCopyright.Text = String.Format("Copyright © 2009 - {0}. HMIS Scaleup Project\nVersion {1}", DateTime.Now.Year.ToString(), Application.ProductVersion);
            IsUserGuest();
            
            PopulateOptions();
            cboOption_SelectedIndexChanged(null, null);
        }
       
        private void cboOption_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //controls the visibility of the form controls based on the option (Backup/Restore) selected 
                layoutControlItem1.Visibility = cboOption.SelectedIndex == 1 ? DevExpress.XtraLayout.Utils.LayoutVisibility.Always : DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                layoutControlItem8.Visibility = cboOption.SelectedIndex == 1 ? DevExpress.XtraLayout.Utils.LayoutVisibility.Always : DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                layoutControlItem6.Visibility = cboOption.SelectedIndex == 1 ? DevExpress.XtraLayout.Utils.LayoutVisibility.Always : DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
     
                layoutControlItem12.Visibility = cboOption.SelectedIndex == 1 ? DevExpress.XtraLayout.Utils.LayoutVisibility.Never : DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                layoutControlItem15.Visibility = cboOption.SelectedIndex == 1 ? DevExpress.XtraLayout.Utils.LayoutVisibility.Never : DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                layoutControlItem5.Visibility = cboOption.SelectedIndex == 1 ? DevExpress.XtraLayout.Utils.LayoutVisibility.Never : DevExpress.XtraLayout.Utils.LayoutVisibility.Always;

                layBackupDatabase.Visibility = cboOption.SelectedIndex == 0 ? DevExpress.XtraLayout.Utils.LayoutVisibility.Always : DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                layRestoreDatabase.Visibility = cboOption.SelectedIndex == 1 ? DevExpress.XtraLayout.Utils.LayoutVisibility.Always : DevExpress.XtraLayout.Utils.LayoutVisibility.Never;

                this.Height = cboOption.SelectedIndex == 1 ? 450 : 430;
            }
            catch (Exception ex)
            {
                DbUtilityHelper.DisplayMessageBox(ex.Message, "error");
            }
        }

        private void btnBackupLocation_Click(object sender, EventArgs e)
        {
            try
            {
                folderBrowserDialog.ShowDialog();
                txtBackupLocation.Text = folderBrowserDialog.SelectedPath;
            }
            catch (Exception ex)
            {
                DbUtilityHelper.DisplayMessageBox(ex.Message, "error");
            }
        }
         
        private void btnSync_Click(object sender, EventArgs e)
        {
            PopulateServers();
        }

        private void frmDbUtility_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel=(canClose==true)? false : true;
        }
        
        private void lkeDatabases_EditValueChanged(object sender, EventArgs e)
        {
            IsUserGuest();
        }

        private void barHelpAbout_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmAbout about = new frmAbout();
            if(!IsAlreadyOpened(about))
                about.ShowDialog();
        }

        private void barSettingEmail_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                frmEmailSetting setting = new frmEmailSetting();

                if (!IsAlreadyOpened(setting))
                    setting.ShowDialog();
            }
            catch (Exception ex)
            {
                DbUtilityHelper.DisplayMessageBox(ex.Message, "error");
            }
        }

        private void barSettingBackup_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmBackupSetting oBackupSetting = new frmBackupSetting();

            if (!IsAlreadyOpened(oBackupSetting))
                oBackupSetting.ShowDialog();
        }

        private void barSkin_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (!String.IsNullOrWhiteSpace(e.Item.Caption))
                {
                    DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle(e.Item.Caption);
                    ((BarCheckItem)e.Item).Checked = true;

                    uiSetting = new UISetting()
                    {
                        Type = "Skin",
                        Name = e.Item.Caption
                    };

                    settingBL.Add(uiSetting);
                }
            }catch(Exception ex)
            {
                DbUtilityHelper.DisplayMessageBox(ex.Message, "error");
            }

        }

        private void lkeServer_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                //Populates databases from the specified server name
                PopulateDatabases(lkeServer.EditValue.ToString());
            }
            catch (Exception ex)
            {
                DbUtilityHelper.DisplayMessageBox("Databases could not be loaded. Please select the server again.\n" + ex.Message, "error");
            }
        }

        private void barSettingServer_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                frmServerSetting oServerSetting = new frmServerSetting();

                if (!IsAlreadyOpened(oServerSetting))
                    oServerSetting.ShowDialog();
            }
            catch (Exception ex)
            {
                DbUtilityHelper.DisplayMessageBox(ex.Message, "error");
            }
        }

        #endregion

        

     }

    public delegate void AddCompletionStatusDelegate(int percent, string status);

    public static class UpdateCompletionStatus
    {

        public static frmDbUtility mainwin;

        public static event AddCompletionStatusDelegate OnNewCompletionStatus;

        public static void ShowCompletionStatus(int percent, string status)
        {
            try
            {
                ThreadSafeCompletionStatus(percent, status);
            }
            catch (Exception ex)
            {
                throw new TargetInvocationException(ex);
            }
        }

        private static void ThreadSafeCompletionStatus(int percent, string status)
        {
            try
            {
                if (mainwin != null && mainwin.InvokeRequired)  // we are in a different thread to the main window
                    mainwin.Invoke(new AddCompletionStatusDelegate(ThreadSafeCompletionStatus), new object[] { percent, status });  // call self from main thread
                else
                    OnNewCompletionStatus(percent, status);
            }
            catch (Exception ex)
            {
                throw new TargetInvocationException(ex);
            }
        }

    }
}