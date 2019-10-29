using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbBackupRestore
{
    public class ServerSetting
    {
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
                throw new InvalidArgumentException("A connection to the database server could not be established\n" + ex.Message);
            }
        }

    }
}
