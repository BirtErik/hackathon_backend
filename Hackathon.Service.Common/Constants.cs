using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hackathon.Service.Common
{
    public static class Constants
    {
        #region Enviroment Variables
        public const string ENV_VAR_DB_CONN_STRING = "POSTGRES_DB_CONNECTION_STRING";
        public const string ENV_VAR_SERVICE_PORT = "SERVICE_PORT";
        #endregion

        #region App Settings
        public const string APP_SET_DB_CONN_STRING = "DatabaseSettings:ConnectionString";
        #endregion
    }
}
