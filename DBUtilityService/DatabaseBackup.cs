using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Microsoft.SqlServer.Management.Smo;
using Microsoft.SqlServer.Management.Common;
using System.IO;
using System.Security.AccessControl;
using ICSharpCode.SharpZipLib.Zip;
using System.Security.Cryptography;

namespace DBUtilityService
{
    public class DatabaseBackup
    {
        /// <summary>
        /// Backup the database and store the .bak file on the specified location. 
        /// Creates the NETWORK_SERVICE user to the specified folder 
        /// </summary>
        public void BackupDatabase(Server server, string backupLocation, string databaseName)
        {
            try
            {

                Backup _bkpDBFull = new Backup();

                _bkpDBFull.Action = BackupActionType.Database;

                _bkpDBFull.Database = databaseName;

                String _userName = "NETWORK SERVICE";

                string _filePath = String.Format("{0}\\{1}_{2:dddd_MMM d_yyyy}.bak", backupLocation, databaseName, DateTime.Now);

                DirectoryInfo _dirInfo = new DirectoryInfo(backupLocation);
                DirectorySecurity _dirSecurity = _dirInfo.GetAccessControl();
                _dirSecurity.AddAccessRule(new FileSystemAccessRule(_userName, FileSystemRights.FullControl, InheritanceFlags.ContainerInherit | InheritanceFlags.ObjectInherit, PropagationFlags.None, AccessControlType.Allow));

                _dirInfo.SetAccessControl(_dirSecurity);

                _bkpDBFull.Devices.AddDevice(_filePath, DeviceType.File);
                _bkpDBFull.BackupSetName = databaseName + " database Backup";
                _bkpDBFull.BackupSetDescription = databaseName + " database - Full Backup";

                _bkpDBFull.ExpirationDate = DateTime.Today.AddDays(10);

                _bkpDBFull.Initialize = false;

                _bkpDBFull.PercentCompleteNotification = 1;

                _bkpDBFull.SqlBackup(server);

            }
            catch (Exception ex)
            {
                throw new IOException(String.Format("Database backup could not successfully completed. {0}", ex.Message));
            }
        }

    }

}
