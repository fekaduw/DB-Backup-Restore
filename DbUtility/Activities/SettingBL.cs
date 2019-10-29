using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using System.Text;
using System.Xml;

namespace DbUtility
{
    public class SettingBL
    {
        EncryptDecrypt encryptDecrypt;
        
        private static string LOCAL_APP_DATA = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "JSI_DBUtility_Settings");
        
        private string SERVER_SETTING_PATH = Path.Combine(LOCAL_APP_DATA, "ServerSettings.xml");
        private string UI_SETTING_PATH = Path.Combine(LOCAL_APP_DATA, "UISettings.xml");
        private string EMAIL_SETTING_PATH = Path.Combine(LOCAL_APP_DATA, "EmailSettings.xml");
        private string BACKUP_SETTING_PATH = Path.Combine(LOCAL_APP_DATA, "BackupSettings.xml");

        public SettingBL()
        {
            encryptDecrypt = new EncryptDecrypt();
        }

        #region Email Setting methods
        public bool Add(EmailSetting setting)
        {
            try
            {
                XmlDocument _doc = new XmlDocument();

                //Create neccessary nodes
                XmlDeclaration _declaration = _doc.CreateXmlDeclaration("1.0", "UTF-8", "yes");
                XmlElement _root = _doc.CreateElement("Settings");

                //sender
                XmlElement _sender = _doc.CreateElement("Sender");
                XmlElement _senderEmail = _doc.CreateElement("Email");
                XmlElement _password = _doc.CreateElement("Password");

                //SMTP server setting
                XmlElement _smtp = _doc.CreateElement("SMTP");

                //message
                //XmlElement _message = _doc.CreateElement("Receiver");
                //XmlElement _subject = _doc.CreateElement("Email");

                //Add sender's email and password
                _senderEmail.InnerText = setting.SenderEmail;
                _password.InnerText = setting.Password;

                //Add smtp setting
                _smtp.InnerText = setting.Host;

                //Construct the document
                _doc.AppendChild(_declaration);
                //doc.AppendChild(comment);
                _doc.AppendChild(_root);

                _root.AppendChild(_sender);
                _sender.AppendChild(_senderEmail);
                _sender.AppendChild(_password);

                //Add receivers' email address
                foreach (var email in setting.ReceiversEmail)
                {
                    //Receiver
                    XmlElement _receiver = _doc.CreateElement("Receiver");
                    XmlElement _receiverEmail = _doc.CreateElement("Email");

                    _root.AppendChild(_receiver);
                    _receiverEmail.InnerText = email;
                    _receiver.AppendChild(_receiverEmail);
                }

                _root.AppendChild(_smtp);

                if (!Directory.Exists(LOCAL_APP_DATA))
                    Directory.CreateDirectory(LOCAL_APP_DATA);

                _doc.Save(EMAIL_SETTING_PATH);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

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

        #endregion

        #region Server Setting methods
        public bool Add(ServerSetting setting)
        {
            try
            {
                XmlDocument _doc = new XmlDocument();

                //Create neccessary nodes
                XmlDeclaration _declaration = _doc.CreateXmlDeclaration("1.0", "UTF-8", "yes");
                XmlElement _root = _doc.CreateElement("Settings");
                XmlElement _server = _doc.CreateElement("Server");
                XmlAttribute _name = _doc.CreateAttribute("Name");
                XmlElement _userName = _doc.CreateElement("UserName");
                XmlElement _password = _doc.CreateElement("Password");
                XmlElement _database = _doc.CreateElement("DefaultDatabase");

                //Add the values for each nodes
                _name.Value = setting.Name;
                _userName.InnerText = setting.UserName;
                _password.InnerText = setting.Password;
                _database.InnerText = setting.Database;

                //Construct the document
                _doc.AppendChild(_declaration);
                //doc.AppendChild(comment);
                _doc.AppendChild(_root);
                _root.AppendChild(_server);
                _server.Attributes.Append(_name);
                _server.AppendChild(_userName);
                _server.AppendChild(_password);
                _server.AppendChild(_database);

                if (!Directory.Exists(LOCAL_APP_DATA))
                    Directory.CreateDirectory(LOCAL_APP_DATA);

                _doc.Save(SERVER_SETTING_PATH);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

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

        #endregion

        #region UI Setting methods
        public bool Add(UISetting uiSetting)
        {
            try
            {
                XmlDocument _doc = new XmlDocument();

                //Create neccessary nodes
                XmlDeclaration _declaration = _doc.CreateXmlDeclaration("1.0", "UTF-8", "yes");
                XmlElement _root = _doc.CreateElement("Settings");
                XmlElement _ui = _doc.CreateElement("UI");
                XmlAttribute _type = _doc.CreateAttribute("Type");
                XmlElement _name = _doc.CreateElement("Name");

                //Add the values for each nodes
                _type.Value = uiSetting.Type;
                _name.InnerText = uiSetting.Name;

                //Construct the document
                _doc.AppendChild(_declaration);
                //doc.AppendChild(comment);
                _doc.AppendChild(_root);
                _root.AppendChild(_ui);
                _ui.Attributes.Append(_type);
                _ui.AppendChild(_name);

                if (!Directory.Exists(LOCAL_APP_DATA))
                    Directory.CreateDirectory(LOCAL_APP_DATA);

                _doc.Save(UI_SETTING_PATH);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public UISetting GetUISetting()
        {
            try
            {
                if (System.IO.File.Exists(UI_SETTING_PATH))
                {
                    XmlDocument _doc = new XmlDocument();
                    _doc.Load(UI_SETTING_PATH);

                    //Get root element
                    XmlElement _root = _doc.DocumentElement;

                    //Get the record at the current index
                    XmlElement _currentUI = (XmlElement)_root.ChildNodes[0];

                    if (_currentUI.ChildNodes.Count > 0)
                    {
                        //Show the record information
                        UISetting _uiSetting = new UISetting();
                        _uiSetting.Type = _currentUI.Attributes["Type"].Value;
                        _uiSetting.Name = _currentUI.GetElementsByTagName("Name")[0].InnerText;

                        return _uiSetting;
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

        #region Backup Period Setting methods
        public bool Add(BackupSetting setting)
        {
            try
            {
                XmlDocument _doc = new XmlDocument();

                //Create neccessary nodes
                XmlDeclaration _declaration = _doc.CreateXmlDeclaration("1.0", "UTF-8", "yes");
                XmlElement _root = _doc.CreateElement("Settings");
                XmlElement _backup = _doc.CreateElement("Backup");
                XmlAttribute _on = _doc.CreateAttribute("On");
                XmlElement _month = _doc.CreateElement("Month");
                XmlElement _day = _doc.CreateElement("Day");
                XmlElement _time = _doc.CreateElement("Time");
                XmlElement _backupLocation = _doc.CreateElement("BackupLocation");

                //Add the values for each nodes
                _on.Value = setting.On;
                _month.InnerText = setting.Month;
                _day.InnerText = setting.Day;
                _time.InnerText = setting.Time;
                _backupLocation.InnerText = setting.BackupLocation;

                //Construct the document
                _doc.AppendChild(_declaration);
                //doc.AppendChild(comment);
                _doc.AppendChild(_root);
                _root.AppendChild(_backup);
                _backup.Attributes.Append(_on);
                _backup.AppendChild(_month);
                _backup.AppendChild(_day);
                _backup.AppendChild(_time);
                _backup.AppendChild(_backupLocation);

                if (!Directory.Exists(LOCAL_APP_DATA))
                    Directory.CreateDirectory(LOCAL_APP_DATA);

                _doc.Save(BACKUP_SETTING_PATH);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

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
                        _setting.On = _currentServer.Attributes["On"].Value;
                        _setting.Month = _currentServer.GetElementsByTagName("Month")[0].InnerText;
                        _setting.Day = _currentServer.GetElementsByTagName("Day")[0].InnerText;
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

        public List<string> GetBackupDays(string days)
        {
            try
            {
                List<string> _dayList = new List<string>();

                if (!string.IsNullOrEmpty(days))
                {
                    string[] _days = days.Split(',');
                    foreach(var _d in _days)
                        _dayList.Add(_d);

                    return _dayList;
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
        public string On { get; set; }
        public string Month { get; set; }
        public string Day { get; set; }
        public string Time { get; set; }
        public string BackupLocation { get; set; }
    }

    public class UISetting
    {
        public string Type { get; set; }
        public string Name { get; set; }
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
