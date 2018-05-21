using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Net;

namespace WF_WorkStationManagement
{
    public class Program
    {
        static void Main(string[] args)
        {

            IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlServerConnString"].ConnectionString);
            foreach (NetStatPortsAndProcessNames.Port s in NetStatPortsAndProcessNames.GetNetStatPorts())
            {
                String portNumber = ConfigurationManager.AppSettings["port"];
                if (s.port_number.Equals(portNumber))
                {
                    string computerName = Dns.GetHostName();
                    var newId = db.Insert(new AliveModel
                    {
                        hostname = computerName,
                        ipAddress = Dns.GetHostEntry(computerName).AddressList[2].ToString(),
                        port = s.port_number,
                        processName = s.name
                    });
                }
            }
        }
    }
}
