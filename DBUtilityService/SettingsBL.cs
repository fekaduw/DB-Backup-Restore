using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace DBUtilityService
{
    public class SettingsBL
    {
        EncryptDecrypt encryptDecrypt;

        private static string LOCAL_APP_DATA = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "JSI_DBUtility_Settings");

        private string SERVER_SETTING_PATH = Path.Combine(LOCAL_APP_DATA, "ServerSettings.xml");
        private string EMAIL_SETTING_PATH = Path.Combine(LOCAL_APP_DATA, "EmailSettings.xml");
        private string BACKUP_SETTING_PATH = Path.Combine(LOCAL_APP_DATA, "BackupSettings.xml");
   
        #region Methods

        /// <summary>
        /// Retrieves the server setting
        /// </summary>
        /// <returns></returns>
        public ServerSetting GetServerSetting()
        {
            try
            {
                if (System.IO.File.Exists(SERVER_SETTING_PATH))
                {
                    XmlDocument _doc = new XmlDocument();
                    _doc.Load(SERVER_SETTING_PATH);

                    //Get root element
                    XmlElement _root = _doc.DocumentElement;

                    //Get the record at the current index
                    XmlElement _currentServer = (XmlElement)_root.ChildNodes[0];

                    if (_currentServer.ChildNodes.Count > 0)
                    {
                        //Show the record information
                        ServerSetting _setting = new ServerSetting();
                        _setting.Name = _currentServer.Attributes["Name"].Value;
                        _setting.UserName = _currentServer.GetElementsByTagName("UserName")[0].InnerText;
                        _setting.Password = EncryptDecrypt.Decrypt(_currentServer.GetElementsByTagName("Password")[0].InnerText, "123");
                        _setting.Database = _currentServer.GetElementsByTagName("DefaultDatabase")[0].InnerText;

                        return _setting;
                    }
                }

                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// Retrieves the email setting
        /// </summary>
        /// <returns></returns>
        public EmailSetting GetEmailSetting()
        {
            try
            {
                if (System.IO.File.Exists(EMAIL_SETTING_PATH))
                {
                    XmlDocument _doc = new XmlDocument();
                    _doc.Load(EMAIL_SETTING_PATH);

                    //Get root element
                    XmlElement _root = _doc.DocumentElement;

                    //Get the record at the current index
                    XmlElement _currentEmail = (XmlElement)_root.ChildNodes[0];

                    if (_currentEmail.ChildNodes.Count > 0)
                    {
                        //Show the record information
                        EmailSetting _setting = new EmailSetting();
                        _setting.SenderEmail = _currentEmail.GetElementsByTagName("Email")[0].InnerText;
                        _setting.Password = EncryptDecrypt.Decrypt(_currentEmail.GetElementsByTagName("Password")[0].InnerText, "123");

                        XmlNodeList _receiver = _root.GetElementsByTagName("Receiver");
                        _setting.ReceiversEmail = new List<string>();

                        foreach (XmlNode r in _receiver)
                        {
                            _setting.ReceiversEmail.Add(r.InnerText);
                        }

                        _setting.Host = _root.GetElementsByTagName("SMTP")[0].InnerText;

                        return _setting;
                    }
                }

                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// Retreives the ackup setting
        /// </summary>
        /// <returns></returns>
        public BackupSetting GetBackupSetting()
        {
            try
            {
                if (System.IO.File.Exists(BACKUP_SETTING_PATH))
                {
                    XmlDocument _doc = new XmlDocument();
                    _doc.Load(BACKUP_SETTING_PATH);

                    //Get root element
                    XmlElement _root = _doc.DocumentElement;

                    //Get the record at the current index
                    XmlElement _currentServer = (XmlElement)_root.ChildNodes[0];

                    if (_currentServer.ChildNodes.Count > 0)
                    {
                        //Show the record information
                        BackupSetting _setting = new BackupSetting();
                        _setting.RepeatOn = _currentServer.Attributes["RepeatOn"].Value;
                        _setting.Period = _currentServer.GetElementsByTagName("Period")[0].InnerText;
                        _setting.Time = _currentServer.GetElementsByTagName("Time")[0].InnerText;
                        _setting.BackupLocation = _currentServer.GetElementsByTagName("BackupLocation")[0].InnerText;

                        return _setting;
                    }
                }

                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DateTime GetBackupPeriod()
        {
            try
            {
                BackupSetting oBackupSetting = new BackupSetting();
                oBackupSetting = GetBackupSetting();
                if (oBackupSetting != null)
                {
                    string time = oBackupSetting.Time.Split(" ");

                    
                    DateTime _today = DateTime.Today;

                    switch (oBackupSetting.RepeatOn)
                    {
                        case "Everyday":
                            return new DateTime(_today.Year,_today.Month, _today.Day,, 
                    }
                }

                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        #endregion
    }

    public class EmailSetting
    {
        public string SenderEmail { get; set; }
        public string Password { get; set; }
        public List<string> ReceiversEmail { get; set; }
        public string Host { get; set; }
    }

    public class ServerSetting
    {
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Database { get; set; }
    }

    public class BackupSetting
    {
        public string RepeatOn { get; set; }
        public string Period { get; set; }
        public string Time { get; set; }
        public string BackupLocation { get; set; }
    }

    public class EncryptDecrypt
    {
        // This constant string is used as a "salt" value for the PasswordDeriveBytes function calls.
        // This size of the IV (in bytes) must = (keysize / 8).  Default keysize is 256, so the IV must be
        // 32 bytes long.  Using a 16 character string here gives us 32 bytes when converted to a byte array.
        private static readonly byte[] initVectorBytes = Encoding.ASCII.GetBytes("tu89geji340t89u2");

        // This constant is used to determine the keysize of the encryption algorithm.
        private const int keysize = 256;

        public static string Encrypt(string plainText, string passPhrase)
        {
            byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);
            using (PasswordDeriveBytes password = new PasswordDeriveBytes(passPhrase, null))
            {
                byte[] keyBytes = password.GetBytes(keysize / 8);
                using (RijndaelManaged symmetricKey = new RijndaelManaged())
                {
                    symmetricKey.Mode = CipherMode.CBC;
                    using (ICryptoTransform encryptor = symmetricKey.CreateEncryptor(keyBytes, initVectorBytes))
                    {
                        using (MemoryStream memoryStream = new MemoryStream())
                        {
                            using (CryptoStream cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
                            {
                                cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
                                cryptoStream.FlushFinalBlock();
                                byte[] cipherTextBytes = memoryStream.ToArray();
                                return Convert.ToBase64String(cipherTextBytes);
                            }
                        }
                    }
                }
            }
        }

        public static string Decrypt(string cipherText, string passPhrase)
        {
            byte[] cipherTextBytes = Convert.FromBase64String(cipherText);
            using (PasswordDeriveBytes password = new PasswordDeriveBytes(passPhrase, null))
            {
                byte[] keyBytes = password.GetBytes(keysize / 8);
                using (RijndaelManaged symmetricKey = new RijndaelManaged())
                {
                    symmetricKey.Mode = CipherMode.CBC;
                    using (ICryptoTransform decryptor = symmetricKey.CreateDecryptor(keyBytes, initVectorBytes))
                    {
                        using (MemoryStream memoryStream = new MemoryStream(cipherTextBytes))
                        {
                            using (CryptoStream cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read))
                            {
                                byte[] plainTextBytes = new byte[cipherTextBytes.Length];
                                int decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);
                                return Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount);
                            }
                        }
                    }
                }
            }
        }
    }
}
