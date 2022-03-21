using HeartFramework.Config;
using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace HeartFramework.Helpers
{
    public class LogHelpers
    {
        //Global Declaration
        private static string _logFileName = "Log_" + Settings.TimeStamp;
        private static StreamWriter _streamw = null;

        //Create a file which can store the log information
        public static void CreateLogFile()
        {
            try
            {
                string dir = Settings.LogPath;
                if (Directory.Exists(dir))
                {
                    _streamw = File.AppendText(dir + _logFileName);
                }
                else
                {
                    Directory.CreateDirectory(dir);
                    _streamw = File.AppendText(dir + _logFileName);
                }
                _streamw = File.AppendText(Settings.ReportPath + _logFileName);
            }catch(Exception e)
            {
                Console.WriteLine("************* Exception : " + e.Message);
            }
        }



        //Create a method which can write the text in the log file
        static void Write(logType logType, string logMessage)
        {
            try
            {
                _streamw.Write("{0} {1} {2} - ", DateTime.Now.ToLongTimeString(), DateTime.Now.ToLongDateString(), logType);
                _streamw.WriteLine(" {0}", logMessage);
                _streamw.Flush();
            }catch(Exception e)
            {
                Console.WriteLine("************* Exception : " + e.Message);
            }
        }

        public static void info(string logMessage)
        {
            Write(logType.INFO, logMessage);
        }

        public static void debug(string logMessage)
        {
            Write(logType.DEBUG, logMessage);
        }

        public static void warn(string logMessage)
        {
            Write(logType.WARN, logMessage);
        }

        public static void error(string logMessage)
        {
            Write(logType.ERROR, logMessage);
        }

        public static void fatal(string logMessage)
        {
            Write(logType.FATAL, logMessage);
        }

        public enum logType
        {
            INFO,
            DEBUG,
            WARN,
            ERROR,
            FATAL
        }


        public static void ReplaceInFile(string OldValue, string NewValue)

        {
            StreamReader reader = new StreamReader("C:\\FileUpdate.txt");
            
            string text = File.ReadAllText("C:\\FileUpdate.txt");
            reader.Close();
            text = text.Replace(OldValue, NewValue);
            File.WriteAllText("C:\\FileUpdate.txt", text);
            reader.Close();
            
        }

        public static string ReadFromFile()
        {
            StreamReader reader = new StreamReader("C:\\FileUpdate.txt");
            string WholeTextPresent = reader.ReadToEnd();
            string TextInLine = reader.ReadLine();
            return WholeTextPresent;
        }
    }

    public class TestDataHelper
    {
        private static StreamWriter _streamw = null;
        private static StreamReader _streamr = null;

        public static string ReadFromTestFile(string filepath)
        {
            StreamReader _streamr = new StreamReader(filepath);
            string line = _streamr.ReadLine();
            string stripped = "";
            while (line!=null)
            {
                line = _streamr.ReadLine();
                stripped = Regex.Replace(line, "[^0-9]", "");
                //   string SplitValue = Regex.Split(line, )
                //   public static string[] Split(string input, string pattern);

            }

            return stripped;
        }

        public static void WriteFile(string filePath, string test, string element, string value)
        {
            string contents = File.ReadAllText(filePath);
            Boolean flag = true;
            string replaced = "";
            _streamr = new StreamReader(filePath);
            string line = _streamr.ReadLine();
            while (line != null)
            {
                if (line.Contains(test + "." + element))
                {
                    replaced = Regex.Replace(contents, line, test + "." + element + "=" + value);
                    flag = false;
                }
                line = _streamr.ReadLine();
            }
            _streamr.Close();

            if (flag)
            {
                _streamw = File.AppendText(filePath);
                _streamw.WriteLine("{0}.{1}={2}", test, element, value);
                _streamw.Flush();
                _streamw.Close();
            }
            else
            {
                File.WriteAllText(filePath, replaced);
            }

        }

       

        public static void ReadFile(string filePath)
        {
            string line;

            try
            {
                
                _streamr = new StreamReader(filePath);
                line = _streamr.ReadLine();
                while (line != null)
                {
                    Console.WriteLine(line);
                    line = _streamr.ReadLine();
                }
             
                _streamr.Close();
                Console.ReadLine();
                
            }

            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            finally
            {
                Console.WriteLine("Executing final block");
            }

    

        }
    }

}