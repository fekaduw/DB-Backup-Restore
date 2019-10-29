using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Net.Mail;
using System.Net;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraSplashScreen;

namespace DbUtility
{
    public partial class frmEmailSetting : DevExpress.XtraEditors.XtraForm
    {
        SettingBL settingBL;
        EmailSetting emailSetting;

        public frmEmailSetting()
        {
            InitializeComponent();

            settingBL = new SettingBL();
            emailSetting = new EmailSetting();

            PopulateData();
        }

     
        private void PopulateData()
        {
            try
            {
                emailSetting = settingBL.GetEmailSetting();
                if(emailSetting !=null)
                {
                    txtEmail.Text = emailSetting.SenderEmail;
                    txtPassword.Text = emailSetting.Password;
                    foreach (var re in emailSetting.ReceiversEmail)
                    lstReceivers.Items.Add(re);
                    
                    txtHost.Text = emailSetting.Host;

                    btnRemove.Enabled = lstReceivers.ItemCount > 0 ? true : false;
                }
            }
            catch (Exception ex)
            {
                DbUtilityHelper.DisplayMessageBox(ex.Message, "error");
            }
        }

        private List<string> GetReceiversEmail()
        {
            List<string> receiversEmail = new List<string>();

            if(lstReceivers.ItemCount > 0)
            {
            
            for (int c = 0; c < lstReceivers.ItemCount; c++)
                receiversEmail.Add(lstReceivers.Items[c].ToString());
            }
            return receiversEmail;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtEmail.Text.Trim()) &&
                    !string.IsNullOrEmpty(txtPassword.Text.Trim()) &&
                    !string.IsNullOrEmpty(txtHost.Text.Trim()) &&
                    lstReceivers.ItemCount > 0)
                {
                    emailSetting = new EmailSetting()
                    {
                        SenderEmail = txtEmail.Text.Trim(),
                        Password = EncryptDecrypt.Encrypt(txtPassword.Text.Trim(), "123"),
                        Host = txtHost.Text.Trim()
                    };
                    emailSetting.ReceiversEmail = GetReceiversEmail();

                    if (settingBL.Add(emailSetting))
                        DbUtilityHelper.DisplayMessageBox("Email setting successfully saved", "information");
                    else
                        DbUtilityHelper.DisplayMessageBox("Email setting could not be saved. Please try agin!", "error");
                }
                else
                {
                    DbUtilityHelper.DisplayMessageBox("Required fields cannot be blank.", "warning");
                }
            }
            catch(Exception ex)
            {
                DbUtilityHelper.DisplayMessageBox(ex.Message,"error"); 
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(txtEmail.Text) &&
                    !string.IsNullOrWhiteSpace(txtPassword.Text) &&
                    lstReceivers.ItemCount>0 &&
                    !string.IsNullOrWhiteSpace(txtHost.Text))
                {
                    SplashScreenManager.ShowForm(typeof(WaitForm1));

                    MailMessage message = new MailMessage();
                    SmtpClient smtp = new SmtpClient();

                    message.From = new MailAddress(txtEmail.Text.Trim());

                    foreach(var re in GetReceiversEmail())
                        message.To.Add(new MailAddress(re));

                    message.Subject = "Database backup info";
                    message.Body = string.Format("Dear all, <br><br>This is to inform you that a database backup has been successfully taken on <b>{0}</b><br><br>regards", DateTime.Now.ToString("f"));  // txtBody.Text;
                    message.IsBodyHtml = true;

                    smtp.Port = 587;
                    smtp.Host = txtHost.Text.Trim(); //"smtp.gmail.com";
                    smtp.EnableSsl = true;
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = new NetworkCredential(txtEmail.Text, txtPassword.Text);
                    smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                    smtp.Send(message);

                    SplashScreenManager.CloseForm();

                    DbUtilityHelper.DisplayMessageBox("Message sucessfully sent", "information");
                }
                else
                    DbUtilityHelper.DisplayMessageBox("Required fields cannot be blank", "warning");
            }
            catch (Exception ex)
            {
                DbUtilityHelper.DisplayMessageBox("Email could not be sent at this time. Please try again!\n" + ex.Message, "error");
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if(!string.IsNullOrWhiteSpace(txtReceiverEmail.Text))
                {
                    //setting.ReceiversEmail.Add(txtReceiverEmail.Text.Trim());
                    lstReceivers.Items.Add(txtReceiverEmail.Text.Trim());
                    
                    txtReceiverEmail.Text = string.Empty;
                    lstReceivers.Refresh();
                    btnRemove.Enabled = lstReceivers.ItemCount > 0 ? true : false;
                    txtReceiverEmail.Focus();
                }
                else
                    DbUtilityHelper.DisplayMessageBox("Receiver's email address cannot be blank", "warning");
            }
            catch(Exception ex)
            {
                DbUtilityHelper.DisplayMessageBox(ex.Message, "error");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            try
            {
                lstReceivers.Items.RemoveAt(lstReceivers.SelectedIndex);
                btnRemove.Enabled = lstReceivers.ItemCount > 0 ? true : false;
            }
            catch (Exception ex)
            {
                DbUtilityHelper.DisplayMessageBox(ex.Message, "error");
            }
        }
    }
}