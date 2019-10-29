using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBUtilityService
{
    public class Connection
    {
        ServerSetting oServerSetting;
        SettingsBL oSettingBL;


        public Connection()
        {
            oServerSetting = new ServerSetting();
            oSettingBL = new SettingsBL();
        }

        /// <summary>
        /// Establishes connection to the database server
        /// </summary>
        public Server Connect()
        {
            try
            {
                oServerSetting = oSettingBL.GetServerSetting();

                if (oServerSetting != null)
                {
                    ServerConnection _serverConnection = new ServerConnection(oServerSetting.Name);

                    _serverConnection.LoginSecure = true;
                    _serverConnection.Login = oServerSetting.UserName;
                    _serverConnection.Password = oServerSetting.Password;

                    return new Server(_serverConnection);
                }

                return null;
            }
            catch (Exception ex)
            {
                return null;
                throw new InvalidArgumentException("A connection to the database server could not be established\n" + ex.Message);
            }
        }

    }
}
