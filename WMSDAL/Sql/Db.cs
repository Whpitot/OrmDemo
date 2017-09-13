using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WMSDAL.Sql
{
    public class Db
    {
        public static DbSession Get()
        {

            // string cns = System.Configuration.ConfigurationSettings.AppSettings["server"].ToString();
            //  string cns = System.Configuration.ConfigurationManager.ConnectionStrings["k3"].ConnectionString;

            string cns = "";
            if (System.Configuration.ConfigurationManager.AppSettings["test"] != null)
            {
                cns = System.Configuration.ConfigurationManager.AppSettings["test"].ToString();
            }
            else
            {
                cns = System.Configuration.ConfigurationManager.ConnectionStrings["test"].ConnectionString;
            }
            return new DbSession(cns);
        }
    }
}
