using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;

 
 
namespace DAl.Sql
{
   public class Db
    {
       public static DbSession Get()
       {
       
         // string cns = System.Configuration.ConfigurationSettings.AppSettings["server"].ToString();
        //  string cns = System.Configuration.ConfigurationManager.ConnectionStrings["k3"].ConnectionString;

           string cns = "";
           if (System.Configuration.ConfigurationManager.AppSettings["db"] != null)
           {
               cns = System.Configuration.ConfigurationManager.AppSettings["db"].ToString();
           }
           else
           {
               cns = System.Configuration.ConfigurationManager.ConnectionStrings["db"].ConnectionString;
           }
           return new DbSession(cns);
       }
       public static DbSession Get(string key)
       {
           string cns = "";
           if (System.Configuration.ConfigurationManager.AppSettings[key] != null)
           {
               cns = System.Configuration.ConfigurationManager.AppSettings[key].ToString();
           }
           else
           {
               cns = System.Configuration.ConfigurationManager.ConnectionStrings[key].ConnectionString;
           }
           return new DbSession(cns);
       }

       public static string GetConnectionString()
       {

           // string cns = System.Configuration.ConfigurationSettings.AppSettings["server"].ToString();
           //  string cns = System.Configuration.ConfigurationManager.ConnectionStrings["k3"].ConnectionString;

           string cns = "";
           if (System.Configuration.ConfigurationManager.AppSettings["db"] != null)
           {
               cns = System.Configuration.ConfigurationManager.AppSettings["db"].ToString();
           }
           else
           {
               cns = System.Configuration.ConfigurationManager.ConnectionStrings["db"].ConnectionString;
           }
           return cns;
       }
    }
}
