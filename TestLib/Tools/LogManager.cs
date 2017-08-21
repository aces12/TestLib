using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TestLib.Tools
{
    public class LogManager
    {
        //로그 파일 형식 : .\LogPath\2017\08\20170818.txt
        public enum LogType { Daily, Monthly }

        private string _path;
        #region Constructor
        public LogManager(string path, LogType logType, string prefix, string postfix)
        {
            _path = path;
            _SetLogPath(logType, prefix, postfix);
        }

        public LogManager(string prefix, string postfix)
            :this(Path.Combine(Application.Root, "Log"), LogType.Daily, prefix, postfix)
        {

        }
        public LogManager()
            : this(Path.Combine(Application.Root, "Log"), LogType.Daily, null, null)
        {
        }
        #endregion

        #region Method
        private void _SetLogPath(LogType logType, string prefix, string postfix)
        {
            string path = String.Empty;
            string name = String.Empty;

            switch(logType)
            {
                case LogType.Daily:
                    path = String.Format(@"{0}\{1}\", DateTime.Now.Year, DateTime.Now.ToString("MM"));
                    name = DateTime.Now.ToString("yyyyMMdd");
                    break;
                case LogType.Monthly:
                    path = String.Format(@"{0}\", DateTime.Now.Year);
                    name = DateTime.Now.ToString("yyyyMM");
                    break;
            }

            _path = Path.Combine(_path, path);
            
            if(!Directory.Exists(_path))
            {
                Directory.CreateDirectory(_path);
            }

            if (!String.IsNullOrEmpty(prefix))
                name = prefix + name;
            if (!String.IsNullOrEmpty(postfix))
                name = name + postfix;
            
            _path = Path.Combine(_path, name);
        }

        public void Write(string data)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(_path, true))
                {
                    writer.Write(data);
                }
            }
            catch (Exception ex)
            { }
        }
        public void WriteLine(string data)
        {
            try
            {
                //FileStream fs = new FileStream(_path, FileMode.Create);
                //using (StreamWriter writer = new StreamWriter(fs))
                using (StreamWriter writer = new StreamWriter(_path, true))
                {

                    writer.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss\t") + data);
                }
                //fs.Close();
            }
            catch (Exception ex)
            {
                //using (StreamWriter writer = new StreamWriter(_path, true))
                //{
                //    writer.WriteLine(ex);
                //}
            }
        }
        //public void WriteConsole(string data)
        //{
        //    Write(data);
        //    Console.Write(data);
        //}
        #endregion
    }
}
