using ChoETL;
using HeartFramework.Config;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using HeartFramework.Helpers;
using Newtonsoft.Json.Linq;
using System.Data;
using Newtonsoft.Json.Schema;
using TechTalk.SpecFlow.Assist;

namespace HeartFramework.Helpers
{

    public static class DatahelperExtensions
    {

        private static Dictionary<string, List<Datacollection>> _dataColList1 = new Dictionary<string, List<Datacollection>>();
        private static string _jsonFileName;
        private static string _jsonFileAllText;

        public static void getCsvData(string fileName)
        {
            using (var reader = new StreamReader(fileName))
            {
                List<string> listA = new List<string>();
                List<string> listB = new List<string>();
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(';');

                    listA.Add(values[0]);
                    listB.Add(values[1]);
                }
            }

        }

        public static void jsonFilePath(string fileName)
        {
            _jsonFileName = fileName;
        }

        public static void readJsonFile(string fileName)
        {
            try { _jsonFileAllText = File.ReadAllText(fileName); }

            catch (Exception e)
            {
                Console.WriteLine("************* Exception : " + e.Message);
            }
        }

   
     
      

    }
     
    
}
