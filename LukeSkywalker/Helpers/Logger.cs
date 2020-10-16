using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LukeSkywalker.Helpers
{
    public class Logger
    {
        static string Logs;

        public void AddLog(string msg)
        {
            var log = "[" + DateTime.Now + "] " + msg + Environment.NewLine;
            Logs = Logs + log;
        }

        public void SaveLogsToFile()
        {
            var path = AppDomain.CurrentDomain.BaseDirectory + @"\Logs\";
            var fileName = "Application Logs "+ DateTime.Now ;
            fileName = fileName.Replace(".","");
            fileName = fileName.Replace(":","");
            fileName = fileName + ".txt";
            
            if (!Directory.Exists(path))
            {
                DirectoryInfo di = Directory.CreateDirectory(path);
            }

            File.WriteAllText(path + fileName, Logs);
        }
    }
   
}
