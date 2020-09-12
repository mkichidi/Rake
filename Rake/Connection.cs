using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rake
{
   public static class Connection
    {
       public static string _lvInvAdminConn = string.Empty;

       public static string InvAdminConn()
       {
           return _lvInvAdminConn = System.Configuration.ConfigurationManager.ConnectionStrings["FleetConnectionString"].ToString();
       }
    }
}
