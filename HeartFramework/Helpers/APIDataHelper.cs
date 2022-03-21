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
using HeartFramework.BaseAPI;
using System.Data;
using Newtonsoft.Json.Schema;
using TechTalk.SpecFlow.Assist;
using TechTalk.SpecFlow.Plugins;
using System.Collections;
using RestSharp;
using System.Text.RegularExpressions;

namespace HeartFramework.Helpers
{

    public static class APIDatahelper
    {

        private static Dictionary<string, List<Datacollection>> _dataColList1 = new Dictionary<string, List<Datacollection>>();
        private static string _csvFileAllText;
        private static string _jsonFileName;
        private static string _jsonFileAllText;

        public static void readCsvFile(string fileName)
        {
            try { _csvFileAllText = File.ReadAllText(fileName); }
            catch (Exception e) { Console.WriteLine("************* Exception : " + e.Message); }
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

        public static T parseJson<T>() where T : new()
        {
            return JsonConvert.DeserializeObject<T>(_jsonFileAllText);
        }

        //Method to convert CSV to JSON
        public static void CSVToNestedJSON<T>() where T : new()
        {
            StringBuilder json = new StringBuilder();
            using (var w = new ChoJSONWriter(json))
            {
                using (var r = ChoCSVReader.LoadText(_csvFileAllText).WithFirstLineHeader()
                     .Setup(s => s.BeforeRecordLoad += (o, e) =>
                     {
                         if (!e.Source.ToString().Contains(ScenarioContext.Current.ScenarioInfo.Title))
                             e.Skip = true;
                     })
                    .Setup(s => s.BeforeRecordFieldLoad += (o, v) =>
                    {
                        if (v.Source == null || v.Source.Equals("") || v.Source.Equals(ScenarioContext.Current.ScenarioInfo.Title))
                            v.Skip = true;
                    })
                    .Configure(s => s.NestedColumnSeparator = '/')
                    .Configure(c => c.ArrayIndexSeparator = '|')
                    )
                    w.Write(r);
            }
            File.WriteAllText(_jsonFileName, json.ToString());
            Common.jsonObj = JsonConvert.DeserializeObject<dynamic>(JsonConvert.SerializeObject(json.ToString()));
            Common.jsonObj = Common.jsonObj.ToString().Substring(1, json.ToString().Length - 2).Trim();
            if (Common.jsonObj.Contains("_DateStamp"))
                Common.jsonObj = Common.jsonObj.Replace("DateStamp", DateTime.Now.ToString(Settings.TimeStampFormat));
            Common.jsonPayload = JObject.Parse(Common.jsonObj);
        }


        public static void AddOrUpdateKey<T>(this Dictionary<T, T> dict, T key, T newValue)
        {
            if (dict.ContainsKey(key))
            {
                dict[key] = newValue;
            }
            else
            {
                //if (key.ToString().Contains("_Value"))
                dict.Add(key, newValue);
            }
        }

        public static dynamic UpdateTokenValue(dynamic jsonString, dynamic TokenName, dynamic newValue)
        {
            try
            {
                JObject jObj = JsonConvert.DeserializeObject(JsonConvert.SerializeObject(jsonString)) as JObject;
                JToken tStr = null;
                if (TokenName.Contains("/"))
                {
                    string tempStr = TokenName;
                    int slashCnt = tempStr.Count(f => f == '/');
                    for (int counter = 0; counter <= slashCnt; counter++)
                    {
                        if (tStr == null)
                        {
                            if (jObj.SelectToken(Common.constData) == null)
                                tStr = jObj.SelectToken(tempStr.ToString().Split('/')[counter]);
                            else
                                if (Regex.IsMatch(tempStr.ToString().Split('/')[counter], @"^\d+$"))
                                tStr = tStr[Int32.Parse(tempStr.ToString().Split('/')[counter])];
                            else
                                tStr = jObj.SelectToken(Common.constData).SelectToken(tempStr.ToString().Split('/')[counter]);
                        }
                        else
                        {
                            if (Regex.IsMatch(tempStr.ToString().Split('/')[counter], @"^\d+$"))
                            {
                                tStr = tStr[Int32.Parse(tempStr.ToString().Split('/')[counter])];
                            }
                            else
                            {
                                tStr = tStr.SelectToken(tempStr.ToString().Split('/')[counter]);
                            }
                        }
                        if (slashCnt == counter)
                        {
                            switch (tStr.Type.ToString().ToLower())
                            {
                                case "integer":
                                    if (newValue.ToString() == "null")
                                        tStr.Replace(null);
                                    else
                                        if (newValue.ToString() == "")
                                        tStr.Replace("");
                                    else
                                        tStr.Replace(Convert.ToInt32(newValue));
                                    break;
                                case "boolean":
                                    if (newValue.ToString() == "null")
                                        tStr.Replace(null);
                                    else
                                        if (newValue.ToString() == "")
                                        tStr.Replace("");
                                    else
                                        tStr.Replace(Convert.ToBoolean(newValue));
                                    break;
                                case "float":
                                    if (newValue.ToString() == "null")
                                        tStr.Replace(null);
                                    else
                                        if (newValue.ToString() == "")
                                        tStr.Replace("");
                                    else
                                        tStr.Replace(Convert.ToDecimal(newValue));
                                    break;
                                case "array":
                                    if (newValue.ToString() == "null")
                                        tStr.Replace(null);
                                    else
                                            if (newValue.ToString() == "")
                                        tStr.Replace("");
                                    else
                                        tStr.Replace(newValue);
                                    break;
                                case "object":
                                    if (newValue.ToString() == "null")
                                        tStr.Replace(null);
                                    else
                                            if (newValue.ToString() == "")
                                        tStr.Replace("");
                                    else
                                        tStr.Replace(newValue);
                                    break;
                                default:
                                    if (newValue.ToString() == "null")
                                        tStr.Replace(null);
                                    else
                                        if (newValue.ToString() == "")
                                        tStr.Replace("");
                                    else
                                        tStr.Replace(newValue);
                                    break;
                            }
                            jsonString = jObj.ToString();
                        }
                    }
                }
                else
                {
                    if (jObj.SelectToken(Common.constData) != null)
                    {
                        tStr = jObj.SelectToken(Common.constData).SelectToken(TokenName);
                    }
                    else
                    {
                        tStr = jObj.SelectToken(TokenName);
                    }

                    switch (tStr.Type.ToString().ToLower())
                    {
                        case "integer":
                            if (newValue.ToString() == "null")
                                tStr.Replace(null);
                            else
                                if (newValue.ToString() == "")
                                tStr.Replace("");
                            else
                                tStr.Replace(Convert.ToInt32(newValue));
                            break;
                        case "boolean":
                            if (newValue.ToString() == "null")
                                tStr.Replace(null);
                            else
                                if (newValue.ToString() == "")
                                tStr.Replace("");
                            else
                                tStr.Replace(Convert.ToBoolean(newValue));
                            break;
                        case "float":
                            if (newValue.ToString() == "null")
                                tStr.Replace(null);
                            else
                                if (newValue.ToString() == "")
                                tStr.Replace("");
                            else
                                tStr.Replace(Convert.ToDecimal(newValue));
                            break;
                        case "array":
                            if (newValue.ToString() == "null")
                                tStr.Replace(null);
                            else
                                    if (newValue.ToString() == "")
                                tStr.Replace("");
                            else
                                tStr.Replace(newValue);
                            break;
                        case "object":
                            if (newValue.ToString() == "null")
                                tStr.Replace(null);
                            else
                                    if (newValue.ToString() == "")
                                tStr.Replace("");
                            else
                                tStr.Replace(newValue);
                            break;
                        default:
                            if (newValue.ToString() == "null")
                                tStr.Replace(null);
                            else
                                if (newValue.ToString() == "")
                                tStr.Replace("");
                            else
                                tStr.Replace(newValue);
                            break;
                    }
                    jsonString = jObj.ToString();
                }
                StringBuilder jsonSb = new StringBuilder();
                jsonSb.Append(jsonString);
                return jsonSb;
            }
            catch(Exception e)
            {
                ReportingHelpers.ChildTest.Fail("Exception Message : "+e.Message);
                return "";
            }
        }

        /// <summary>
        ///Method to create payload for multiple test data passing via feature file
        /// </summary>
        /// <param name=""></param>
   
        public static void featureToJSONformultipleDatas<T>(Table table) where T : new()
        {
            
            Table t = new Table((string[])table.Header);
            Common.jsonObjMultiple = new dynamic[table.Rows.Count];
            for (int i=0;i<table.Rows.Count;i++)
            {
                t.AddRow(table.Rows[i]);
                featureToJSON<T>(t);
                Common.jsonObjMultiple[i] = Common.jsonObj;
                t = new Table((string[])table.Header);
            }
        }

        /// <summary>
        ///Method to create payload for single test data passing via feature file
        /// </summary>
        /// <param name=""></param>
        public static void featureToJSON<T>(Table table) where T : new()
        {
            try
            {
                //TODO - Validation is pending for null or blank values
                string testData = table.ToString().TrimStart('|');
                string testData1 = "";
                if (testData.Contains("|\r\n|"))
                    testData1 = testData.Replace("|\r\n|", "\r\n");
                StringBuilder json = new StringBuilder();
                using (var w = new ChoJSONWriter(json))
                {
                    using (var r = ChoCSVReader.LoadText(testData1).WithFirstLineHeader().WithDelimiter("|")
                       .Configure(c => c.FileHeaderConfiguration.IgnoreColumnsWithEmptyHeader = true)
                       .Configure(s => s.NestedColumnSeparator = '/')
                       .Configure(s => s.IgnoreFieldValueMode = ChoIgnoreFieldValueMode.None)
                       //  .Configure(s => s.NullValue = null)
                       //   .Configure(s => s.NullValueHandling = ChoNullValueHandling.Default)
                       .Configure(c => c.ArrayIndexSeparator = '.'))
                    { w.Write(r); }
                    string schemaJson = null;
                    dynamic jsonStr = JsonConvert.DeserializeObject(json.ToString().Substring(1, json.Length - 1));
                    schemaJson = File.ReadAllText(Environment.CurrentDirectory.ToString() + Settings.jsonfilepath + Common.schemaFile[typeof(T).Name]);
                    JsonSchema schema = JsonSchema.Parse(schemaJson);
                    foreach (var row in table.Rows[0])
                    {
                        var currentRow = row.Key;
                        dynamic jsonStrCopy = jsonStr;
                        dynamic dataType = null;
                        dynamic dataKey, dataValue = null;
                        dataKey = currentRow.ToString();

                        if (row.Value == "null" || row.Value == "") ;
                        else
                        {
                            if (!currentRow.Contains("/"))
                            {
                                dataType = schema.Properties[Common.constData].Properties[currentRow].Type.ToString().ToLower();
                                switch (dataType)
                                {
                                    case "integer":
                                        dataValue = Convert.ToInt32(jsonStrCopy[currentRow]);
                                        json = UpdateTokenValue(jsonStr, dataKey, dataValue);
                                        jsonStr = JObject.Parse(json.ToString());
                                        break;
                                    case "float":
                                        dataValue = Convert.ToDecimal(jsonStrCopy);
                                        json = UpdateTokenValue(jsonStr, dataKey, dataValue);
                                        jsonStr = JObject.Parse(json.ToString());
                                        break;
                                    case "boolean":
                                        jsonStrCopy = jsonStrCopy[currentRow];
                                        if (jsonStrCopy.ToString().ToLower() == "true")
                                        {
                                            dataValue = true;
                                        }
                                        else
                                        {
                                            if (jsonStrCopy.ToString().ToLower() == "false")
                                            {
                                                dataValue = false;
                                            }
                                            else
                                            {
                                                ReportingHelpers.ChildTest.Info("Value for key: " + dataKey + "is :" + dataValue);
                                            }
                                        }
                                        json = UpdateTokenValue(jsonStr, dataKey, dataValue);
                                        jsonStr = JObject.Parse(json.ToString());
                                        break;
                                    default:
                                        break;
                                }
                            }

                            else
                            {
                                int slashCnt = currentRow.Count(f => f == '/');
                                dynamic schemaData = schema.Properties[Common.constData];
                                for (int counter = 0; counter <= slashCnt; counter++)
                                {
                                    if (Regex.IsMatch(dataKey.ToString().Split('/')[counter], @"^\d+$"))
                                    {
                                        jsonStrCopy = jsonStrCopy[Int32.Parse(dataKey.ToString().Split('/')[counter])];
                                        schemaData = schemaData.Items[Int32.Parse(dataKey.ToString().Split('/')[counter])];
                                    }
                                    else
                                    {
                                        jsonStrCopy = jsonStrCopy.SelectToken(dataKey.ToString().Split('/')[counter]);
                                        schemaData = schemaData.Properties[dataKey.ToString().Split('/')[counter]];
                                    }
                                    if (counter == slashCnt)
                                    {
                                        dataType = schemaData.Type.ToString().ToLower();
                                        switch (dataType)
                                        {
                                            case "integer":
                                                dataValue = Convert.ToInt32(jsonStrCopy);
                                                json = UpdateTokenValue(jsonStr, dataKey, dataValue);
                                                jsonStr = JObject.Parse(json.ToString());
                                                break;
                                            case "float":
                                                dataValue = Convert.ToDecimal(jsonStrCopy);
                                                json = UpdateTokenValue(jsonStr, dataKey, dataValue);
                                                jsonStr = JObject.Parse(json.ToString());
                                                break;
                                            case "boolean":
                                                if (jsonStrCopy.ToString().ToLower() == "true")
                                                {
                                                    dataValue = true;
                                                }
                                                else
                                                {
                                                    if (jsonStrCopy.ToString().ToLower() == "false")
                                                    {
                                                        dataValue = false;
                                                    }
                                                    else
                                                    {
                                                        ReportingHelpers.ChildTest.Info("Value for key: " + dataKey + "is :" + dataValue);
                                                    }
                                                }
                                                json = UpdateTokenValue(jsonStr, dataKey, dataValue);
                                                jsonStr = JObject.Parse(json.ToString());
                                                break;
                                            default:
                                                break;
                                        }
                                    }
                                }
                            }
                        }
                        Common.jsonObj = JsonConvert.DeserializeObject<dynamic>(JsonConvert.SerializeObject(json.ToString()));

                        if (Common.jsonObj.ToString().First() == '[')
                            Common.jsonObj = Common.jsonObj.ToString().Substring(1, Common.jsonObj.ToString().Length - 1).Trim();

                        if (Common.jsonObj.ToString().Last() == ']')
                            Common.jsonObj = Common.jsonObj.ToString().Substring(0, Common.jsonObj.ToString().Length - 2).Trim();

                        if (Common.jsonObj.Contains("_DateStamp"))
                            Common.jsonObj = Common.jsonObj.Replace("DateStamp", DateTime.Now.ToString(Settings.TimeStampFormat));
                        //Common.jsonPayload = JObject.Parse(Common.jsonObj);
                    }
                    if (Common.jsonObj.ToLower().Contains("null"))
                        Common.jsonObj = Common.jsonObj.Replace("\"null\"", "null");
                }
            }
            catch(Exception e)
            {
                ReportingHelpers.ChildTest.Fail("Exception Message: "+e.Message);
            }
        }

        public static string getFeatureData(Table e, string key)
        {
            dynamic res = "";
            var dict = new Dictionary<string, dynamic>();
            foreach (var row in e.Rows)
            {
                res = row[key];
            }
            return res;
        }
        public static dynamic MappingExcelToServiceModel<dynamic>(string sheetName, string colName = "Test Case ID")
        {
            //Dictionary<string, string> rowData = ExcelHelpers.getRowData("POC_CoreServices");
            //string excelFileName = Environment.CurrentDirectory.ToString() + Settings.TestData;
            //ExcelHelpers.ExcelToDataTable(excelFileName);
            Dictionary<string, string> rowData1 = new Dictionary<string, string>();
            Dictionary<string, string> rowData2 = new Dictionary<string, string>();

            List<int> rowList = new List<int>();
            List<Datacollection> dataCol1 = ExcelHelpers._dataColList[sheetName];

            foreach (var data in dataCol1)
            {
                //if(data.Key.Equals(colName) && data..Equals(ScenarioContext.Current.ScenarioInfo.Title)) { }
                if (data.colName.Equals(colName) && data.colValue.Equals(ScenarioContext.Current.ScenarioInfo.Title))
                    rowList.Add(data.rowNumber);
                //rowList.Add(data.);
            }

            using (var outFile = File.CreateText(Environment.CurrentDirectory.ToString() + Settings.jsonfilepath + "ProfileService_Organization_DataPost.json"))
            {
                using (var writer = new JsonTextWriter(outFile))
                {
                    writer.Formatting = Formatting.Indented;
                    writer.WriteStartArray();

                    foreach (var row in rowList)
                    {
                        foreach (var data in dataCol1)
                        {
                            if (row != 0 && data.rowNumber.Equals(row))
                            {
                                AddOrUpdateKey(rowData1, data.colName, data.colValue);
                                if (data.colName.Contains("_Value"))
                                {
                                    if (data.colValue.Equals(""))
                                    {
                                        rowData2.Add(data.colName.ToString().Split("_")[0], null);
                                    }
                                    else
                                    {
                                        if (data.colValue.Equals("{}"))
                                            rowData2.Add(data.colName.ToString().Split("_")[0], Convert.ToChar(123) + "" + Convert.ToChar(125));
                                        else
                                            rowData2.Add(data.colName.ToString().Split("_")[0], data.colValue);
                                    }

                                }
                            }

                        }
                        //JObject json = JsonConvert.DeserializeObject(rowData1);
                        string json = JsonConvert.SerializeObject(rowData2, Formatting.Indented);

                        //JObject json1 = (JObject)JsonConvert.DeserializeObject(json);
                        Common.jsonObj = JsonConvert.DeserializeObject(json).ToString();
                        //var jsonFile = JsonConvert.DeserializeObject(json);

                        //LogHelpers.info("Generated payload is ->"+ Common.jsonObj);
                        //string jsonString = (new JavaScriptSerializer()).Serialize((object)rowData1);
                        writer.WriteRawValue(rowData2.ToString());
                        //writer.WriteStartObject();

                        //int count = rowData1.Count;
                        //    string dataE = "[";

                        //    foreach (KeyValuePair<string, string> entry in rowData1)
                        //    {
                        //        if (!(entry.Key == colName || entry.Key == "IsList"))
                        //        {
                        //            if (entry.Value.Contains("|"))
                        //            {
                        //                foreach (var v in entry.Value.Split("|"))
                        //                {
                        //                    if (!entry.Value.Split("|").Last().Equals(v))
                        //                        dataE = dataE + "\"" + v + "\"" + ",";

                        //                    else dataE = dataE + "\"" + v + "\"";
                        //                }
                        //                dataE = dataE + "]";

                        //                    writer.WritePropertyName(entry.Key);
                        //                    writer.WriteRawValue(dataE);
                        //            }
                        //            else
                        //            {

                        //                    writer.WritePropertyName(entry.Key);
                        //                    writer.WriteRawValue(dataE);

                        //            }
                        //        }
                        //    }
                        //    writer.WriteEndObject();
                    }
                    //writer.WriteEndArray();
                }



            }

            return JsonConvert.DeserializeObject<dynamic>(JsonConvert.SerializeObject(_jsonFileName));
        }

        public static void ExcelToJson(string sheetName, string colName = "Test Case ID")
        {
            Dictionary<string, string> rowData = new Dictionary<string, string>();
            List<int> rowList = new List<int>();
            List<Datacollection> dataCol = ExcelHelpers._dataColList[sheetName];

            foreach (var data in dataCol)
            {
                if (data.colName.Equals(colName) && data.colValue.Equals(ScenarioContext.Current.ScenarioInfo.Title))
                    rowList.Add(data.rowNumber);
            }

            using (var outFile = File.CreateText(Environment.CurrentDirectory.ToString() + Settings.jsonfilepath + "tenantServiceDataPost.json"))
            {
                using (var writer = new JsonTextWriter(outFile))

                {
                    writer.Formatting = Formatting.Indented;
                    writer.WriteStartArray();

                    foreach (var row in rowList)
                    {
                        foreach (var data in dataCol)
                        {
                            if (row != 0 && data.rowNumber.Equals(row))
                                AddOrUpdateKey(rowData, data.colName, data.colValue);
                        }

                        writer.WriteStartObject();
                        int count = rowData.Count;
                        string dataE = "[";

                        foreach (KeyValuePair<string, string> entry in rowData)
                        {
                            if (!(entry.Key == colName || entry.Key == "IsList"))
                            {
                                if (entry.Value.Contains("|"))
                                {
                                    foreach (var v in entry.Value.Split("|"))
                                    {
                                        if (!entry.Value.Split("|").Last().Equals(v))
                                            dataE = dataE + "\"" + v + "\"" + ",";

                                        else dataE = dataE + "\"" + v + "\"";
                                    }
                                    dataE = dataE + "]";

                                    writer.WritePropertyName(entry.Key);
                                    writer.WriteRawValue(dataE);
                                }
                                else
                                {
                                    writer.WritePropertyName(entry.Key);
                                    writer.WriteValue(entry.Value);
                                }
                            }
                        }
                        writer.WriteEndObject();
                    }
                    writer.WriteEndArray();
                }



            }
        }
    }
}
