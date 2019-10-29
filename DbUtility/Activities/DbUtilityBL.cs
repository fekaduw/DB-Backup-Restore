using System;

using System.Data.SqlClient;
using System.IO;
using System.Security.AccessControl;
using Microsoft.SqlServer.Management.Smo;
using Microsoft.SqlServer.Management.Common;
using System.Data;
using System.Reflection;
using ICSharpCode.SharpZipLib.Zip;
using ICSharpCode.SharpZipLib.Core;
using System.Data.Sql;
using System.ServiceProcess;

namespace DbUtility
{
    public class DbUtilityBL
    {
        #region Member Variables

        //public delegate void ProgressUpdate(int value, string status);
        //public event ProgressUpdate OnProgressUpdate;

        private string userName;
        private string password;
        private bool isLoginSecured;
        private string dbName;
        private string dbBackupLocation;

        private SqlConnection sqlConn;
        private string filePath;

        private bool isCompleted;
        private bool hasError;

        private int currentProgress;
        private int progressMax;
        private int getPercent;

        private string serverName;
        Microsoft.SqlServer.Management.Smo.Server server;

        #endregion

        #region Properties

        public bool TaskIsBackup { get; set; }

        public string UserName{get;set;}

        public string Password { get; set; }

        public string DbName { get; set; }

        public string DbBackupLocation { get; set; }

        public SqlConnection SqlConn { get; set; }

        public string FilePath { get; set; }

        public bool IsLoginSecured { get; set; }

        public string ServerName { get; set; }

        public Microsoft.SqlServer.Management.Smo.Server Server { get; set; }

        public bool HasError { get; set; }

        public int CurrentProgress { get; set; }
        public bool IsCompleted { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Establishes connection to the database server
        /// </summary>
        public void Connect()
        {
            try
            {
                ServerConnection _serverConnection = new ServerConnection(ServerName);

                //IsLoginSecured is used to determine the Authentication type. If true, Windows Authentication; otherwise, SQL Server Authentication will be considered
                if (!IsLoginSecured)
                {
                    _serverConnection.LoginSecure = IsLoginSecured;
                    _serverConnection.Login = UserName;
                    _serverConnection.Password = Password;
                }

                Server = new Server(_serverConnection);
            }
            catch (Exception ex)
            {
                throw new InvalidArgumentException("A connection to the database server could not be established\n"+ex.Message);
            }
        }

        /// <summary>
        /// Backup the database and store the .bak file on the specified location. 
        /// Creates the NETWORK_SERVICE user to the specified folder 
        /// </summary>
        public void BackupDatabase()
        {
            try
            {
                Backup _bkpDBFull = new Backup();

                _bkpDBFull.Action = BackupActionType.Database;

                _bkpDBFull.Database = DbName;

                String _userName = "NETWORK SERVICE";

                FilePath = DbBackupLocation + "\\" + DbName + "_" + String.Format("{0:dddd_MMM d_yyyy}", DateTime.Now) + ".bak";

                DirectoryInfo _dirInfo = new DirectoryInfo(DbBackupLocation);
                DirectorySecurity _dirSecurity = _dirInfo.GetAccessControl();
                _dirSecurity.AddAccessRule(new FileSystemAccessRule(_userName, FileSystemRights.FullControl, InheritanceFlags.ContainerInherit | InheritanceFlags.ObjectInherit, PropagationFlags.None, AccessControlType.Allow));

                _dirInfo.SetAccessControl(_dirSecurity);

                _bkpDBFull.Devices.AddDevice(FilePath, DeviceType.File);
                _bkpDBFull.BackupSetName = DbName + " database Backup";
                _bkpDBFull.BackupSetDescription = DbName + " database - Full Backup";

                _bkpDBFull.ExpirationDate = DateTime.Today.AddDays(10);

                _bkpDBFull.Initialize = false;

                _bkpDBFull.PercentCompleteNotification = 1;
                _bkpDBFull.PercentComplete += new PercentCompleteEventHandler(PercentComplete);

                _bkpDBFull.SqlBackup(Server);

                IsCompleted = true;
            }
            catch (Exception ex)
            {
                IsCompleted = false;
                throw new IOException(String.Format("Database backup could not successfully completed. {0}", ex.Message));
            }
        }

        /// <summary>
        /// This method restores the specified database from the backup file (.bak)
        /// </summary>
        public void RestoreDatabase()
        {
            string _extractedBakFile = String.Empty;

            try
            {
                if (Server != null)
                {
                    Restore _restoreDatabase = new Restore();
                    _restoreDatabase.Action = RestoreActionType.Database;

                    _restoreDatabase.Database = DbName;

                    //Extracts the zip file

                    if (FilePath.EndsWith(".zip"))
                        _extractedBakFile = ExtractZipFile(FilePath);
                    else
                        _extractedBakFile = FilePath;

                    if (String.IsNullOrEmpty(_extractedBakFile))
                        throw new InvalidArgumentException("File extraction failed. Please try again!");

                    BackupDeviceItem bkpDevice = new BackupDeviceItem(_extractedBakFile, DeviceType.File);

                    _restoreDatabase.Devices.Add(bkpDevice);

                    _restoreDatabase.ReplaceDatabase = true;
                    _restoreDatabase.PercentComplete += new PercentCompleteEventHandler(PercentComplete);
                    _restoreDatabase.SqlRestore(Server);
                    IsCompleted = true;
                }
                else
                {
                    IsCompleted = false;
                    throw new InvalidArgumentException("A connection to the database server could not be established");
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Database restore could not be successfully completed\n"+ex.Message);
            }
            finally
            {
                //check if the .bak is an extracted file. If so, delete .bak and leave the .zip file
                string _zipFile = _extractedBakFile.Replace(".bak", ".zip");

                if (!String.IsNullOrEmpty(_extractedBakFile) && File.Exists(_zipFile))
                    File.Delete(_extractedBakFile);
            }
        }

        /// <summary>
        /// Shows the percentage of work completed when backuping/restoring
        /// </summary>
        /// <returns></returns>
        public void PercentComplete(object sender, PercentCompleteEventArgs e)
        {
            try
            {
                string _message = TaskIsBackup==true ? "Database backup in progress..." : "Database restore in progress...";
                UpdateCompletionStatus.ShowCompletionStatus(e.Percent, _message);
                CurrentProgress = e.Percent;
                Console.WriteLine(e.Percent);
            }
            catch (Exception ex)
            {
                throw new TargetInvocationException(ex);
            }
        }

        /// <summary>
        /// Returns the list of available database servers
        /// </summary>
        /// <returns></returns>
        public DataTable GetServers()
        {
            ServiceController oController = new ServiceController("SQL Server Browser");
            if (oController.Status.Equals(ServiceControllerStatus.Stopped) || oController.Status.Equals(ServiceControllerStatus.Paused))
                oController.Start();

            ////This fetches those servers that are locally available
            //DataTable _dtServers = SmoApplication.EnumAvailableSqlServers(true);

            //if (_dtServers.Rows.Count > 0)
            //    return _dtServers;

            DataTable _serverList = SqlDataSourceEnumerator.Instance.GetDataSources();
            if (_serverList.Rows.Count > 0)
            {
                DataTable _servers = new DataTable();
                _servers.Columns.Add("Name");

                foreach (DataRow _srv in _serverList.Rows)
                {
                    _servers.Rows.Add(string.Concat(_srv["ServerName"], "\\", _srv["InstanceName"]));
                }

                return _servers;
            }

            return null;
        }

        /// <summary>
        /// Reads and returns database names (HMIS, MCSDB) from xml file (Databases.xml)
        /// </summary>
        /// <returns></returns>
        public DataTable GetDatabases()
        {
            Assembly _assembly = Assembly.GetExecutingAssembly();

            DataSet _dsDatabases = new DataSet();

            _dsDatabases.ReadXml(_assembly.GetManifestResourceStream("DbUtility.BL.Databases.xml"));

            return _dsDatabases.Tables[0];
        }

        /// <summary>
        /// Reads and returns database names (HMIS, MCSDB) from the specified server name
        /// </summary>
        /// <returns></returns>
        public DataTable GetDatabases(String serverName)
        {
            try
            {
                Server _server = new Server(serverName);

                DataTable _databases = new DataTable();
                _databases.Columns.Add("Database");
                foreach (Database _db in _server.Databases)
                    _databases.Rows.Add(_db.Name);

                return _databases;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// reads the selected server password from xml file
        /// </summary>
        /// <returns>server password</returns>
        public string GetServerPassword(string dbName)
        {
            Assembly _assembly = Assembly.GetExecutingAssembly();

            DataSet _dsDatabases = new DataSet();

            _dsDatabases.ReadXml(_assembly.GetManifestResourceStream("DbUtility.BL.Databases.xml"));

            for (int c = 0; c < _dsDatabases.Tables[0].Rows.Count; c++)
            {
                if (_dsDatabases.Tables[0].Rows[c]["name"].Equals(dbName))
                    return Convert.ToString(_dsDatabases.Tables[0].Rows[c]["password"]);
            }

            return string.Empty;
        }

        /// <summary>
        /// This method is used to compress the .bak file using SharpZipLib library
        /// </summary>
        /// <param name="bkFileName">.bak file to be compressed to .zip</param>
        /// <returns></returns>
        public bool CompressDbBackup()
        {
            try
            {
                string zipFilePath = FilePath.Replace(".bak", ".zip");

                using (ZipOutputStream zipStream = new ZipOutputStream(File.Create(zipFilePath)))
                {
                    //Compression level 0-9 (9 is highest)
                    zipStream.SetLevel(4);

                    //Add an entry to our zip file
                    ZipEntry entry = new ZipEntry(Path.GetFileName(FilePath));
                    entry.DateTime = DateTime.Now;
                    zipStream.Password = String.Format(Password);
                    zipStream.PutNextEntry(entry);
                    
                    //to check
                    double _sofarReadSize = 0;

                    byte[] buffer = new byte[4096];
                    int byteCount = 0;
                    double totalByte;

                    using (FileStream inputStream = File.OpenRead(FilePath))
                    {
                        byteCount = inputStream.Read(buffer, 0, buffer.Length);
                        totalByte = inputStream.Length ;
                        _sofarReadSize += byteCount;

                        while (byteCount > 0)
                        {
                            zipStream.Write(buffer, 0, byteCount);
                            
                            int progressPercentage = (int)((_sofarReadSize/totalByte) * 100);
                            
                            byteCount = inputStream.Read(buffer, 0, buffer.Length);
                            _sofarReadSize += byteCount;
                            
                            UpdateCompletionStatus.ShowCompletionStatus(progressPercentage,"File compression in progress...");
                        }
                    }
                }

                File.Delete(FilePath);
                
                return true;

            }
            catch (Exception ex)
            {   
                return false;
                throw new TargetInvocationException(ex);
            }
        }

        /// <summary>
        /// Extracts the .zip file
        /// </summary>
        /// <param name="zipFileName">zip file to be extracted </param>
        /// <returns></returns>
        public string ExtractZipFile(string zipFileName)
        {
            ZipFile zf = null;

            string fullZipToPath = String.Empty;
            string outputFolder = Path.GetDirectoryName(zipFileName);

            try
            {
                FileStream fs = File.OpenRead(zipFileName);
                zf = new ZipFile(fs);
                zf.Password = Password; //GetServerPassword(DbName);
                
                int byteCount = 0;
                double totalByte;
                double _sofarReadSize = 0;

                foreach (ZipEntry zipEntry in zf)
                {
                    if (!zipEntry.IsFile)
                    {
                        continue;           // Ignore directories
                    }
                    String entryFileName = zipEntry.Name;

                    byte[] buffer = new byte[4096];     // 4K is optimum
                    Stream zipStream = zf.GetInputStream(zipEntry);

                    // Manipulate the output filename here as desired.
                    fullZipToPath = Path.Combine(outputFolder, entryFileName);
                    string directoryName = Path.GetDirectoryName(fullZipToPath);

                    if (directoryName.Length > 0)
                        Directory.CreateDirectory(directoryName);

                    using (FileStream streamWriter = File.Create(fullZipToPath))
                    {
                        byteCount = streamWriter.Read(buffer, 0, buffer.Length);
                        totalByte = streamWriter.Length;
                        _sofarReadSize += byteCount;

                        StreamUtils.Copy(zipStream, streamWriter, buffer);

                        int progressPercentage = (int)((_sofarReadSize / totalByte) * 100);

                        UpdateCompletionStatus.ShowCompletionStatus(progressPercentage, "Extracting file in progress...");
                    }
                }
            }
            finally
            {
                if (zf != null)
                {
                    zf.IsStreamOwner = true;
                    zf.Close();
                }
            }
            return fullZipToPath; //extracted file path
        }

        #endregion
    }

    
}
