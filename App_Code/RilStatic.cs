using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
/// 
/// system.configuration
/// <summary>
/// Summary description for LoginStatic
/// </summary>
namespace ril.estatic
{
    public class RilStatic
    {
        public static string ReturnConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["ServidorBD"].ToString();
        }
    }
}
