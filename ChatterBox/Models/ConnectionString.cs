using Microsoft.Extensions.Logging;
using Serilog;

namespace ChatterBox.Models
{
    public class ConnectionString
    {

        public string value;

        public ConnectionString(string connectionStringValue)
        {
            if (connectionStringValue == null)
            {
                Log.Logger.Error($"No Db Connection String supplied", connectionStringValue);
                Environment.Exit(4313);
            }
            value = connectionStringValue;
        }
    }
}