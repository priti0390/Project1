using System;
using NUnit.Framework;

namespace HeartFramework.Helpers
{
    public static class AssertHelper
    {

        /// <summary>
        ///Method to validate values if they are equal
        /// </summary>
        public static void AreEqual(string expected, string actual)
        {
            bool flag=false;
            try
            {
                Assert.AreEqual(expected,actual);
            }
            catch(Exception)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                flag =true;  
                Console.WriteLine("Failed Assertion: Expected was <" +expected+ "> but actual is <" + actual+ ">");
                Console.ResetColor();
            }
            if(flag==false)
            {
                Console.WriteLine("Passed Assertion: Expected was <" + expected + "> and actual is also <" + actual+ ">");
            }
        }
        
    }
}
