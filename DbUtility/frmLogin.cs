using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;
using DevExpress.XtraWaitForm;

namespace DbUtility
{
    public partial class frmLogin : DevExpress.XtraEditors.XtraForm
    {
        private short noOfTries;
        private const short MAX_TRIES = 3;

        //sets the Login types
        enum LoginType { GUEST, ADMIN};

        //holds the logged in name. This will be checked on the main form. Admin account will have backup/restore option where
        //as Guest account can only take a backup
        public string UserName
        {
            get;
            set;
        }

        LoginType loggedInAs;

        public frmLogin()
        {
            InitializeComponent();

            noOfTries = 1;

            loggedInAs = LoginType.ADMIN;

            if (Singleton.Instance.UISettings != null)
                DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle(Singleton.Instance.UISettings.Name);

        }

        #region Methods

        /// <summary>
        /// Generates new password
        /// </summary>
        /// <returns></returns>
        private string GeneratePassword()
        {
            try
            {
                return String.Format("p@$$admin@{0}", DateTime.Today.Day.ToString());
            }
            catch (Exception ex)
            {
                DbUtilityHelper.DisplayMessageBox("Password could not be generated at this time. Try again\n"+ex.Message,"error");
                return null;
            }
        }

        /// <summary>
        /// Validates login information
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns>Returns true if user name/password are correct</returns>
        private bool ValidateLogin(string userName, string password)
        {
            try
            {
                //default user name is admin (lower case) and password combination is p@$$admin@{today's date} eg: p@$$admin@21
                return userName.ToLower().Equals("admin") && password.Equals(GeneratePassword()) ? true : false;
            }
            catch (Exception ex)
            {
                DbUtilityHelper.DisplayMessageBox("The system could allow you to login. Try later!\n" + ex.Message, "error");
                UserName = null;
                return false;
            }
        }

        #endregion

        #region Event Handlers
        
        private void frmLogin_Load(object sender, EventArgs e)
        {
            lblCopyright.Text = String.Format("Copyright © 2009 - {0} \nHMIS Scaleup Project", DateTime.Now.Year.ToString());
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (loggedInAs == LoginType.GUEST)
            {
                UserName = "Guest";

                this.Close();
            }
            else if (noOfTries < MAX_TRIES)
            {
                if (!String.IsNullOrWhiteSpace(txtUserName.Text) && !String.IsNullOrWhiteSpace(txtPassword.Text))
                {
                    var _userName = txtUserName.Text.Trim();
                    var _password = txtPassword.Text.Trim();

                    if (ValidateLogin(_userName, _password))
                    {
                        UserName = _userName;
                        this.Close();
                    }
                    else
                    {
                        DbUtilityHelper.DisplayMessageBox("Incorrect user name and/or password. Please retry again.", "Error");
                        txtUserName.Text = UserName = String.Empty;
                        txtPassword.Text = String.Empty;
                        txtUserName.Focus();
                        noOfTries++;
                    }
                }
                else
                {
                    if (string.IsNullOrWhiteSpace(txtUserName.Text))
                    {
                        DbUtilityHelper.DisplayMessageBox("User name can not be blank", "warning");
                        UserName = string.Empty;
                        txtUserName.Focus();
                    }
                    else
                    {
                        DbUtilityHelper.DisplayMessageBox("Password can not be blank", "warning");
                        txtPassword.Focus();
                    }
                }
            }
            else
            {
                DbUtilityHelper.DisplayMessageBox("Too many wrong login attempts. Good Bye!", "Information");
                UserName = string.Empty;
                this.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void chkGuestLogin_CheckedChanged(object sender, EventArgs e)
        {
            loggedInAs = chkGuestLogin.CheckState == CheckState.Checked ? LoginType.GUEST : LoginType.ADMIN;
            
            switch (loggedInAs)
            {
                case LoginType.GUEST:
                    txtUserName.Enabled = txtPassword.Enabled =false;
                    break;
                case LoginType.ADMIN:
                    txtUserName.Enabled = txtPassword.Enabled =true;
                    break;
            }
        }

        #endregion

        private void frmLogin_Activated(object sender, EventArgs e)
        {
            txtUserName.Focus();
        }
    }
}