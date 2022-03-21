﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HeartFramework.BaseAPI;

namespace HeartFramework.Config
{
    public class Settings
    {

        public static int Timeout { get; set; }

        public static string IsReporting { get; set; }

        public static string TestType { get; set; }

        public static string AUT { get; set; }

        public static string AUT2 { get; set; }

        public static string AUT3 { get; set; }

        public static string jsonfilepath { get; set; }
        public static string BuildName { get; set; }

        public static string IsLog { get; set; }

        public static string LogPath { get; set; }

        public static string ReportPath { get; set; }

        public static string ReportFilename { get; set; }

        public static string Environment { get; set; }

        public static string TestData { get; set; }

        public static string CsvTestData { get; set; }

        public static string JsonTestData { get; set; }
        public static string Run { get; set; }

        public static string TimeStamp { get; set; }

        public static string TimeStampFormat { get; set; }


        public static string TempPath { get; set; }
    }
}
