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

namespace DbUtility.BL
{
    public class SettingBL
    {
        EncryptDecrypt encryptDecrypt;

        public SettingBL()
        {
            encryptDecrypt = new EncryptDecrypt();
        }

        #region Email Setting methods
        public bool Add(EmailSetting setting)
        {
            try
            {
                using (XmlWriter writer = XmlWriter.Create("Settings.xml"))
                {
                    writer.WriteStartDocument();
                    writer.WriteStartElement("Settings");

                    writer.WriteStartElement("EmailSetting");
                    writer.WriteStartElement("Sender");
                    writer.WriteElementString("Email", setting.SenderEmail);
                    writer.WriteElementString("Password", setting.Password);
                    writer.WriteEndElement();

                    foreach (var email in setting.ReceiversEmail)
                    {
                        writer.WriteStartElement("Receiver");
                        writer.WriteElementString("Email", email);
                        writer.WriteEndElement();
                    }

                    writer.WriteStartElement("Message");
                    writer.WriteElementString("Subject", setting.Subject);
                    writer.WriteElementString("Body", setting.Body);
                    writer.WriteElementString("Host", setting.Host);
                    writer.WriteEndElement();

                    writer.WriteEndElement();
                    writer.WriteEndDocument();
                    
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public EmailSetting GetEmailSetting()
        {
            EmailSetting setting = new EmailSetting();
            setting.ReceiversEmail = new List<string>();

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("settings.xml");
            
            //sender info
            XmlNodeList senderNodeList = xmlDoc.DocumentElement.SelectNodes("EmailSetting/Sender");
            if (senderNodeList.Count >0)
            {
                setting.SenderEmail = senderNodeList[0].SelectSingleNode("Email").InnerText;
                setting.Password = EncryptDecrypt.Decrypt(senderNodeList[0].SelectSingleNode("Password").InnerText, "123");

                //receiver email
                XmlNodeList receiverNodeList = xmlDoc.DocumentElement.SelectNodes("EmailSetting/Receiver");
                foreach (XmlNode receiverNode in receiverNodeList)
                    setting.ReceiversEmail.Add(receiverNode["Email"].InnerText);

                //message detail
                XmlNodeList messageNodeList = xmlDoc.DocumentElement.SelectNodes("EmailSetting/Message");
                setting.Host = messageNodeList[0].SelectSingleNode("Host").InnerText;
                setting.Subject = messageNodeList[0].SelectSingleNode("Subject").InnerText;
                setting.Body = messageNodeList[0].SelectSingleNode("Body").InnerText;

                return setting;
            }

            return null;
        }

        #endregion

        #region Server Setting methods
        public bool Add(ServerSetting setting)
        {
            try
            {
                using (XmlWriter writer = XmlWriter.Create("Settings.xml"))
                {
                    writer.WriteStartDocument();
                    writer.WriteStartElement("Settings");

                    writer.WriteStartElement("ServerSetting");
                    writer.WriteElementString("ServerName", setting.ServerName);
                    writer.WriteElementString("UserName", setting.UserName);
                    writer.WriteElementString("Password", setting.Password);
                    writer.WriteEndElement();

                    writer.WriteEndElement();
                    writer.WriteEndDocument();

                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public ServerSetting GetServerSetting()
        {
            ServerSetting setting = new ServerSetting();

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("settings.xml");

            XmlNodeList senderNodeList = xmlDoc.DocumentElement.SelectNodes("ServerSetting");
            if (senderNodeList.Count > 0)
            {
                setting.ServerName = senderNodeList[0].SelectSingleNode("ServerName").InnerText;
                setting.UserName = senderNodeList[0].SelectSingleNode("UserName").InnerText;
                setting.Password = EncryptDecrypt.Decrypt(senderNodeList[0].SelectSingleNode("Password").InnerText, "123");

                return setting;
            }

            return null;
        }

        #endregion

        #region UI Setting methods
        public void Add(UISetting uiSetting)
        {
            using (XmlWriter writer = XmlWriter.Create("UISettings.xml"))
            {
                writer.WriteStartDocument();
                    writer.WriteStartElement("Settings");
                        writer.WriteStartElement("Skin");
                            writer.WriteElementString("Name", uiSetting.SkinName);
                        writer.WriteEndElement();
                    writer.WriteEndElement();
                writer.WriteEndDocument();
            }
        }

        public UISetting GetUISetting()
        {
            UISetting uiSetting = new UISetting();
            
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("UISettings.xml");

            //sender info
            XmlNodeList senderNodeList = xmlDoc.DocumentElement.SelectNodes("Skin");
            uiSetting.SkinName = senderNodeList[0].SelectSingleNode("Name").InnerText;

            return uiSetting;
        }

        #endregion

        #region Backup Period Setting methods
        public void Add(BackupPeriodSetting backupPeriodSetting)
        {
            using (XmlWriter writer = XmlWriter.Create("BackupPeriodSettings.xml"))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("Settings");
                writer.WriteStartElement("BackupSetting");
                writer.WriteElementString("RepeatOn", backupPeriodSetting.RepeatOn);
                writer.WriteElementString("Period", backupPeriodSetting.Period);
                writer.WriteElementString("Time", backupPeriodSetting.Time);
                writer.WriteEndElement();
                writer.WriteEndElement();
                writer.WriteEndDocument();
            }
        }

        public BackupPeriodSetting GetBackupPeriodSetting()
        {
            BackupPeriodSetting backupPeriodSetting = new BackupPeriodSetting();

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("BackupPeriodSettings.xml");

            //sender info
            XmlNodeList senderNodeList = xmlDoc.DocumentElement.SelectNodes("BackupSetting");
            backupPeriodSetting.RepeatOn = senderNodeList[0].SelectSingleNode("RepeatOn").InnerText;
            backupPeriodSetting.Period = senderNodeList[0].SelectSingleNode("Period").InnerText;
            backupPeriodSetting.Time = senderNodeList[0].SelectSingleNode("Time").InnerText;
            return backupPeriodSetting;
        }

        #endregion
    }

    public class EmailSetting
    {
        public string SenderEmail { get; set; }        
        public string Password { get; set; }
        public List<string> ReceiversEmail { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public string Host { get; set; }
    }
    public class ServerSetting
    {
        public string ServerName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }

    public class BackupPeriodSetting
    {
        public string RepeatOn { get; set; }
        public string Period { get; set; }
        public string Time { get; set; }
    }

    public class UISetting
    {
        public string SkinName { get; set; }
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
