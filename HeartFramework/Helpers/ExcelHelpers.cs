using ExcelDataReader;
using HeartFramework.Config;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace HeartFramework.Helpers
{
    public class ExcelHelpers
    {

        public static Dictionary<string, List<Datacollection>> _dataColList = new Dictionary<string, List<Datacollection>>();

        //private List<Datacollection> _dataCol = new List<Datacollection>();


        /// <summary>
        /// Storing all the excel values in to the in-memory collections
        /// </summary>
        /// <param name="fileName"></param>
        private static List<Datacollection> PopulateInCollection(DataTable table)
        {
            List<Datacollection> dataCol = new List<Datacollection>();

            //Iterate through the rows and columns of the Table
            for (int row = 1; row <= table.Rows.Count; row++)
            {
                for (int col = 0; col < table.Columns.Count; col++)
                {
                    Datacollection dtTable = new Datacollection()
                    {
                        rowNumber = row,
                        colName = table.Columns[col].ColumnName,
                        //colValue = table.Rows[row - 1][col].ToString()
                        colValue = GetCustomData(table.Rows[row - 1][col].ToString())
                    };
                    //Add all the details for each row
                    dataCol.Add(dtTable);
                }
            }
            return dataCol;
        }

        /// <summary>
        /// Reading all the datas from Excelsheet
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static void ExcelToDataTable(string fileName)
        {
            try
            {
                System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
                using (var stream = File.Open(fileName, FileMode.Open, FileAccess.Read))
                {
                    using (var reader = ExcelReaderFactory.CreateReader(stream))
                    {
                        var result = reader.AsDataSet(new ExcelDataSetConfiguration()
                        {
                            ConfigureDataTable = (data) => new ExcelDataTableConfiguration()
                            {
                                UseHeaderRow = true,
                            }
                        });
                        DataTableCollection table = result.Tables;
                        for (int i = 0; i < table.Count; i++)
                        {
                            //Store it in DataTable
                            DataTable resultTable = table[i];
                            string tableName = table[i].TableName;
                            List<Datacollection> dataCol = PopulateInCollection(resultTable);
                            _dataColList.Add(tableName, dataCol);
                        }

                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("************* Exception : " + e.Message);
            }
        }

        public static string ReadData(int rowNumber, string columnName, string tableName)
        {
            try
            {
                //Retriving Data using LINQ to reduce much of iterations
                string data = (from colData in _dataColList[tableName]
                               where colData.colName == columnName && colData.rowNumber == rowNumber
                               select colData.colValue).SingleOrDefault();

                //var datas = dataCol.Where(x => x.colName == columnName && x.rowNumber == rowNumber).SingleOrDefault().colValue;
                return data.ToString();
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public static Dictionary<string, string> getRowData(int rowNumber, string tableName)
        {
            Dictionary<string, string> rowData = new Dictionary<string, string>();
            try
            {
                List<Datacollection> dataCol = _dataColList[tableName];
                foreach (var data in dataCol)
                {
                    if (data.rowNumber.Equals(rowNumber))
                        rowData.Add(data.colName, data.colValue);
                }
                return rowData;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public static Dictionary<string, string> getRoleData(string role, string colName = "Role", string sheetName = "Accounts")
        {
            Dictionary<string, string> roleData = new Dictionary<string, string>();

            try
            {
                int row = 0;
                List<Datacollection> dataCol = _dataColList[sheetName];
                foreach (var data in dataCol)
                {

                    if (data.colName.Equals(colName) && data.colValue.Equals(role))
                        row = data.rowNumber;
                    if (row != 0 && data.rowNumber.Equals(row))
                    {
                        if (data.colName.Equals("Password"))
                            roleData.Add(data.colName, CryptHelper.DecryptString(data.colValue));
                        else
                            roleData.Add(data.colName, data.colValue);
                    }
                }
                return roleData;
            }
            catch (Exception e)
            {
                return null;
            }

            return roleData;
        }

        public static string GetCustomData(string data)
        {
            string UpdatedValue, cellKey = "";
            string[] temp = data.Split('_');
            int idx = data.LastIndexOf('_');

            if (idx > 0)
            {
                cellKey = data.Substring(idx + 1);
            }

            /*if (temp.Length > 1)
            {
                cellKey = temp[temp.Length-1];
            }*/

            switch (cellKey)
            {
                case "DateStamp":
                    //UpdatedValue = temp[0] + "_" + DateTime.Now.ToString(Settings.TimeStampFormat);
                    UpdatedValue = data.Substring(0, idx) + "_" + DateTime.Now.ToString(Settings.TimeStampFormat);
                    break;
                case "Encrypted":
                    UpdatedValue = CryptHelper.DecryptString(data.Substring(0, idx));
                    break;
                default:
                    UpdatedValue = data;
                    break;
            }

            return UpdatedValue;
        }
        
        public static Dictionary<string, string> getRowData(string sheetName, string colName = "Test Case ID")
        {
            Dictionary<string, string> rowData = new Dictionary<string, string>();

            try
            {
                int row = 0;
                List<Datacollection> dataCol = _dataColList[sheetName];
                foreach (var data in dataCol)
                {
                    if (data.colName.Equals(colName) && data.colValue.Equals(ScenarioContext.Current.ScenarioInfo.Title))
                        row = data.rowNumber;
                    if (row != 0 && data.rowNumber.Equals(row))
                    {
                        if (data.colName.Equals("Password"))
                            rowData.Add(data.colName, CryptHelper.DecryptString(data.colValue));
                        else
                            rowData.Add(data.colName, data.colValue);
                    }
                }
                return rowData;
            }
            catch (Exception e)
            {
                ////ReportingHelpers.ChildTest.Fail("User not able to find the data for the row: " + ScenarioContext.Current.ScenarioInfo.Title);
                Assert.Fail();
                return null;
            }
        }
    }

    public class Datacollection
    {
        public int rowNumber { get; set; }
        public string colName { get; set; }
        public string colValue { get; set; }
    }

}
