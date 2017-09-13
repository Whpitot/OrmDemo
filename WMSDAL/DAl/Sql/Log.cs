using System;
using System.Collections.Generic;
using System.Text;

namespace DAl.Sql
{
    public class Log
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger("DAL");
        static Log()
        {

        }
        public static void Info(string msg)
        {
            if (log.IsInfoEnabled)
                log.Info(msg);
        }
        public static void Info(string msg, params object[] pam)
        {
            if (log.IsInfoEnabled)
                log.InfoFormat(msg, pam);
        }
        public static void Error(string msg, Exception er)
        {
            if (log.IsErrorEnabled)
                log.Error(msg, er);
        }
        public static void Debug(string msg, Exception er)
        {
            if (log.IsDebugEnabled)
                log.Debug(msg, er);
        }
        public static void Debug(string msg)
        {
            if (log.IsDebugEnabled)
                log.Debug(msg);

        }
        public static void Debug(string msg, params object[] pam)
        {
            if (log.IsDebugEnabled)
                log.DebugFormat(msg, pam);
        }
        public static void Warn(string msg)
        {
            if (log.IsWarnEnabled) log.Warn(msg);
        }
    }
}
