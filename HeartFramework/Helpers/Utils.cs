using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

/**
* @author ajamini
*
* @date - 8/5/2019 1:10:16 PM 
*/

namespace HeartFramework.Helpers
{
    public static class Utils
    {
        /// <summary>
        ///To check if a string is alphanumeric
        /// </summary> 
        public static bool IsAlphaNumeric(String strToCheck)
        {
            Regex AlphaNumericPattern = new Regex("[^a-zA-Z0-9]");
            return !AlphaNumericPattern.IsMatch(strToCheck);
        }

        /// <summary>
        ///To check if a string is in valid date format
        /// </summary> 
        public static bool IsDate(String strToCheck)
        {
            Regex IsDate = new Regex("^(1[0-2]|0[1-9])/(3[01]|[12][0-9]|0[1-9])/[0-9]{4}$"); //^([0]?[0-9]|[1][0-2])[.\/-]([0]?[1-9]|[1|2][0-9]|[3][0|1])[.\/-]([0-9]{4}|[0-9]{2})$
            return !IsDate.IsMatch(strToCheck);
        }


        /// <summary>
        /// To store application ID/ any other data for a solution. Parameters: 
        /// IDValue= Value You Want To Store in the file
        /// FileName= XML File Name you want to write.
        /// </summary> 
        public static void XMLFile(String IDValue, String FileName)
        {
            string TestCaseName = NUnit.Framework.TestContext.CurrentContext.Test.FullName;
            string ApplicationRunning = ConfigurationManager.AppSettings["run"].ToUpper();
            string filePath = Environment.CurrentDirectory.ToString() + "\\Data\\" + ConfigurationManager.AppSettings["run"].ToUpper() + "\\" + FileName;
            string filePath2 = "C:\\TFS\\Automation\\Trunk\\Heart\\HeartTest\\Data\\" + ConfigurationManager.AppSettings["run"].ToUpper() + "\\" + FileName;
            //string filePath3 = @"C:\TFS\Automation\Trunk\Heart\HearTest\Data\DynamicFiles";
            //Console.WriteLine(filePath2);
            XDocument xDoc = new XDocument(new XElement(ApplicationRunning, new XElement("IDValue", IDValue)));
            try
            {
                xDoc.Save(filePath);
            }

            catch (Exception E)
            {
                Directory.CreateDirectory(filePath);
                xDoc.Save(filePath);
                ////ReportingHelpers.ChildTest.Info(E);

            }
        }

        /// <summary>
        /// To store application ID/ any other data for a solution. Parameters: 
        /// SolutionName= "SF424", "GRANTS", "AOPS", etc. The SolutionName= ConfigurationManager.AppSettings["run"].ToUpper().
        /// FileName= XML File Name you want to read.
        /// </summary> 
        public static string ReadXML(String FileName, String SolutionName)
        {
            string filePath = Environment.CurrentDirectory.ToString() + "\\Data\\" + ConfigurationManager.AppSettings["run"].ToUpper() + "\\" + FileName;
            XDocument doc = XDocument.Load(filePath);

            var query = doc.Descendants(SolutionName).Select(s => new
            {
                IDValue = s.Element("IDValue").Value
            }).ToList();
            string IDValue = query[0].IDValue;
            return IDValue;
        }


    }
}
