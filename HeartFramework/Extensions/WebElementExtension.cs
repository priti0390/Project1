using AventStack.ExtentReports;
using HeartFramework.Base;
using HeartFramework.Config;
using HeartFramework.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using TechTalk.SpecFlow;

namespace HeartFramework.Extensions
{
    public static class WebElementExtension
    {

        /// <summary>
        /// Select element from dropdownlist by text
        /// </summary>
        public static void SelectDDL(this IWebElement element, string value)
        {
            SelectElement ddl = new SelectElement(element);
            ddl.SelectByText(value);
        }

        /// <summary>
        /// Mover Hover on an element
        /// </summary>
        public static void Hover(this IWebElement element)
        {
            Actions action = new Actions(DriverContext.Driver);
            action.MoveToElement(element).Perform();
        }

        /// <summary>
        /// Mover Hover and click on on an element
        /// </summary>
        public static void HoverAndClick(this IWebElement elementToHover, IWebElement elementToClick)
        {
            Actions action = new Actions(DriverContext.Driver);
            action.MoveToElement(elementToHover).Click(elementToClick).Build().Perform();
        }

        /// <summary>
        /// Get element Text
        /// </summary>
        /// 
        public static string GetText(IWebElement element)
        {
            return element.Text;
        }

        /// <summary>
        /// Get the selected text from a dropdown element
        /// </summary>
        public static string GetSelectedDropDown(IWebElement element)
        {
            SelectElement ddl = new SelectElement(element);
            return ddl.SelectedOption.Text;
        }

        /// <summary>
        ///  Get the all selected list dropdown element
        /// </summary>
        public static IList<IWebElement> GetSelectedListOptions(IWebElement element)
        {
            SelectElement ddl = new SelectElement(element);
            return ddl.AllSelectedOptions;
        }


        /// <summary>
        /// Check if the element exist
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public static string IsElementPresent(this IWebElement element)
        {
            try
            {
                bool b = element.Displayed;
                return "true";
            }
            catch (Exception e)
            {
                return "false";
            }
        }

        /// <summary>
        /// Assert if the Element is present
        /// </summary>
        /// <param name="element"></param>
        public static void AssertElementPresent(this IWebElement element, string elementName)
        {
            try
            {
                bool b = element.Displayed;
                ReportingHelpers.ChildTest.Pass(elementName + " Element exists");
            }
            catch (Exception e)
            {
                ReportingHelpers.ChildTest.Fail(elementName + " - " + e.Message);
            }

        }

        /// <summary>
        /// Assert if the Element text matches with a text
        /// </summary>
        public static void AssertElementTextCompare(this IWebElement element, string elementName, string compareWith)
        {
            if (element.Text.Equals(compareWith))
            {
                ReportingHelpers.ChildTest.Pass(compareWith + " - text matches in element " + elementName);

            }
            else
            {
                ReportingHelpers.ChildTest.Fail(compareWith + " - text does not match in element " + elementName);
            }
        }

        /// <summary>
        /// Assert if the expected text is present in an element text. 
        /// </summary>
        public static void AssertElementTextExists(this IWebElement element, string elementName, string compareWith)
        {
            if (element.Text.Trim().Contains(compareWith))
            {
                ReportingHelpers.ChildTest.Pass(element.Text + " - text exists in element " + elementName);
            }
            else
            {
                ReportingHelpers.ChildTest.Fail(element.Text + " - text does not exists in element " + elementName);
            }
        }

        /// <summary>
        /// Assert if the Element contains a text
        /// </summary>
        public static void AssertElementTextExists(this IWebElement element, string elementName)
        {
            if (element.Text.Equals(""))
            {
                ReportingHelpers.ChildTest.Fail(element.Text + " - text does not exists in element " + elementName);
            }
            else
            {
                ReportingHelpers.ChildTest.Pass(element.Text + " - text exists in element " + elementName);
            }
        }
        /// <summary>
        /// File Upload
        /// </summary>
        /// 
        public static void UploadFile(String FileName)
        {
            String filePath = Environment.CurrentDirectory.ToString() + "\\Data\\" + FileName;
            SendKeys.SendWait(@filePath);
            SendKeys.SendWait(@"{Enter}");

        }

        public static void ElementUploadFile(this IWebElement element, String FileName)
        {
            String filePath = Environment.CurrentDirectory.ToString() + "\\Data\\" + FileName;
            element.SendKeys(filePath);
        }

        /// <summary>
        /// Wait for Element Present
        /// </summary>
        /// 
        public static void ElementWait(this IWebElement element)
        {
            int time = 500;
            while (element.IsElementPresent().Equals("false"))
            {
                Thread.Sleep(500);
                time += 500;
                if (time == 5000)
                    break;
            }
        }

        /// <summary>
        /// Wait for Element Displayed
        /// </summary>
        /// 
        public static void ElementDisplayWait(this IWebElement element)
        {
            int time = 500;
            while (element.Displayed.Equals("false"))
            {
                Thread.Sleep(500);
                time += 500;
                if (time == 5000)
                    break;
            }
        }

        /// <summary>
        /// Wait for Element Enabled
        /// </summary>
        /// 
        public static void ElementEnableWait(this IWebElement element)
        {
            int time = 500;
            while (element.Enabled.Equals("false"))
            {
                Thread.Sleep(500);
                time += 500;
                if (time == 5000)
                    break;
            }
        }

        /// <summary>
        /// Wait for Element until Clickable
        /// </summary>
        ///
        public static void ElementWaitUntilClickable(this IWebElement element)
        {
            try
            {
                var wait = new WebDriverWait(DriverContext.Driver, TimeSpan.FromSeconds(10));
                wait.Until(ExpectedConditions.ElementToBeClickable(element));
            }
            catch (Exception E)  
            {
                element.ConditionalWait();
            }

        }
            /// <summary>
            /// wait for frame to be present if yes it will switch
            /// </summary
            public static void WaitForFrame(this IWebElement element, String framename)
            {
                element.Click();
                var wait = new WebDriverWait(DriverContext.Driver, TimeSpan.FromSeconds(10));
                switch (framename)
                {
                    case "dialogIframe":                    
                        wait.Until(ExpectedConditions.FrameToBeAvailableAndSwitchToIt("dialogIframe"));
                        break;

                    case "GB_frame_confirmLoginMsg":
                        wait.Until(ExpectedConditions.FrameToBeAvailableAndSwitchToIt("GB_frame_confirmLoginMsg"));
                        break;

                    case "activityForm":
                        wait.Until(ExpectedConditions.FrameToBeAvailableAndSwitchToIt("activityForm"));
                        break;

                    default:
                        ReportingHelpers.ChildTest.Info("Frame not found");
                        break;
                }   
           
            }

        /// <summary>
        /// Check if the Element is Alphanumeric
        /// </summary>
        ///
        public static bool FieldIsAlphaNumeric(this IWebElement element)
        {
            Regex AlphaNumericPattern = new Regex("[^a-zA-Z0-9]");
            return !AlphaNumericPattern.IsMatch(element.Text);
        }

        /// <summary>
        /// Check if the Element is a valid date
        /// </summary>
        ///
        public static bool FieldIsDate(this IWebElement element)
        {
            Regex IsDate = new Regex("^(1[0-2]|0[1-9])/(3[01]|[12][0-9]|0[1-9])/[0-9]{4}$");
            return !IsDate.IsMatch(element.Text);
        }

        /// <summary>
        /// Waits for the webelement to be clickable and ignores exceptions
        /// </summary>
        ///
        public static void ConditionalWait(this IWebElement element)
        {
            try
            {
                DriverContext.Driver.WaitForReady();
                DefaultWait<IWebDriver> ConditionalWait = new DefaultWait<IWebDriver>(DriverContext.Driver);
                ConditionalWait.Timeout = TimeSpan.FromSeconds(10);
                ConditionalWait.PollingInterval = TimeSpan.FromMilliseconds(250);
                ConditionalWait.IgnoreExceptionTypes(typeof(TargetInvocationException));
                ConditionalWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
                ConditionalWait.IgnoreExceptionTypes(typeof(InvalidOperationException));
                element = ConditionalWait.Until(ExpectedConditions.ElementToBeClickable(element));
            }

            catch (Exception e)
            {
                ReportingHelpers.ChildTest.Info("Info - " + e.Message);
            }
        }

        /// <summary>
        /// Uses java script to click on the webelement if the normal click doesn't work ( mostly this is observed in Chrome web browser)
        /// </summary>
        ///
        public static void JSClick(this IWebElement element)
        {
            IJavaScriptExecutor executor = (IJavaScriptExecutor)DriverContext.Driver;
            executor.ExecuteScript("document.body.style.zoom = '1'");

            try
            {
                element.Click();
            }

            catch (Exception e)
            {
                ReportingHelpers.ChildTest.Info("Info" + e.Message);
                executor.ExecuteScript("arguments[0].click();", element);

            }

        }

        /// <summary>
        /// Click on the element until a new page opens
        /// </summary>
        ///
        public static void ClickUntilNextPage(this IWebElement element)
        {
            string pageTitle = DriverContext.Driver.Title;
            int counter = 0;
            while (DriverContext.Driver.Title == pageTitle)
            {
                element.JSClick();
                counter++;
                if (counter == 3)
                    break;
            }
        }

        /// <summary>
        /// Scroll the page using an element
        /// </summary>
        /// 

        public static void JSScroll(this IWebElement element)
        {

            {
                IJavaScriptExecutor executor = (IJavaScriptExecutor)DriverContext.Driver;
                executor.ExecuteScript("arguments[0].scrollIntoView(true);", element);
            }
        }

        /// <summary>
        /// Uses java script to read input from inupt field if the normal xpath is not working for the element to read.
        /// </summary>
        ///
        public static string JSInputRead(this IWebElement element)
        {
            {
                IJavaScriptExecutor executor = (IJavaScriptExecutor)DriverContext.Driver;
                return executor.ExecuteScript("return arguments[0].value", element) as string;
            }
        }

        /// <summary>
        //To verify error exist or not  
        /// </summary>
        public static void ToVerifyErrorExist()
        {

            try
            {
                if (DriverContext.Driver.FindElements(By.XPath("//a[@class='EntityViewFirstErrorFieldLnk']")).Count > 0)
                {
                    ReportingHelpers.ChildTest.Fail("Error exist while navigating to next SmartForm" + MediaEntityBuilder.CreateScreenCaptureFromPath(DriverContext.Driver.TakeScreenShot()).Build());
                }
                else
                {
                    ReportingHelpers.ChildTest.Pass("Error does not exist while navigating to next SmartForm");
                }
            }
            catch (Exception e)
            {

                ReportingHelpers.ChildTest.Pass("Error does not exist while navigating to next SmartForm");

            }

        }

        /// <summary>
        /// To verify error exist on the given page
        /// </summary> 
        public static bool ErrorCheck()
        {
            try
            {
                if (DriverContext.Driver.FindElement(By.XPath("//*[contains(@class,'Error')]")).Text != null)
                {
                    ReportingHelpers.ChildTest.Fail("Error exists on the SmartForm with page title- " + DriverContext.Driver.Title);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            { 
            return false;

            }
        }

       
        /// <summary>
        /// Wait and click on a webelement
        /// </summary> 
        public static void WaitClickElement(this IWebElement e)
        {
            e.ConditionalWait();
            e.JSClick();
        }        

        /// <summary>
        /// To select checkbox and RadioButton from Excel datasheet
        /// </summary> 
        public static void SelCheckboxAndRadioBtn(this IList<IWebElement> elementsList, string ExcelValue)
        {

            foreach (IWebElement Var in elementsList)
            {
                if (Var.Text.Equals(ExcelValue))
                {
                    Var.Click();
                    break;
                }
            }
        }

        // <summary>
        /// This Specific method is used to click on WebElement
        /// </summary> 
        public static void ClickEx(this IWebElement element)
        {
            element.Click();
        }

        // <summary>
        /// This method is used to enter data in Text Field
        /// </summary> 
        public static void SendKeysEx(this IWebElement element, string data)
        {
            element.SendKeys(data);
        }
    

        /// <summary>
        /// To select the radio button by clicking on text
        /// </summary>
        /// <param name="ElementList"></param>
        /// <param name="ElementTextToClick"></param>
        public static void SelectRadioButton(this IList<IWebElement> ElementList, string ElementTextToClick)
        {
            int flag = 0;
            foreach (IWebElement element in ElementList)
            {
                if (element.Text.Equals(ElementTextToClick))
                {
                    element.ClickEx();
                    flag = 1;
                }
            }
            if(flag == 0)
            {
                ReportingHelpers.ChildTest.Fail("User is not able to click on " + ElementTextToClick);
            }
        }

        /// <summary>
        /// select single or multiple check box
        /// </summary>
        /// <param name="ElementList"></param>
        /// <param name="ExcelValue"></param>
        public static void SelectCheckBox(this IList<IWebElement> ElementList, string ExcelValue)
        {
            int flag = 0;
            //If it is the multiple check box, the values should be segrigated by | (pipe) operator in Excel
            string[] CheckBoxValues = ExcelValue.Split('|');

            foreach (string value in CheckBoxValues)
            {
                foreach (IWebElement element in ElementList)
                {
                    if (element.Text.Equals(value))
                    {
                        element.ClickEx();
                        flag = 1;
                    }
                }
            }
            if (flag == 0)
            {
                ReportingHelpers.ChildTest.Fail("User is not able to click on " + ExcelValue);
            }

        }

        /// <summary>
        /// To select the radio button using Attribute value of the element
        /// </summary>
        /// <param name="ElementList"></param>
        /// <param name="ElementTextToClick"></param>
        public static void SelectRadioButton_WithAttributeValue(this IList<IWebElement> ElementList, string AttributeValue)
        {
            foreach (IWebElement element in ElementList)
            {
                if (element.GetAttribute("value").Equals(AttributeValue))
                {
                    element.ClickEx();
                }
            }
        }

        public static string RemoveSpecialChar(this IWebElement element)
        {

            string text = element.Text.Replace(",", string.Empty).Replace("$", string.Empty);

            return text;

        }

        public static void TextCompare_WithAttributevalue(this IWebElement element, string AttributeValue)
        {
               if (element.GetAttribute("value").Equals(AttributeValue))
                {
                    ReportingHelpers.ChildTest.Pass(AttributeValue + " - text matches in element " + element.GetAttribute("value"));
                }
                else
                {
                    ReportingHelpers.ChildTest.Fail(AttributeValue + " - text does not match in element " + element.GetAttribute("value"));
                }
        }


        /// <summary>
        /// Check if the element is selected
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public static string IsElementSelected(this IWebElement element)
        {
            try
            {
                bool b = element.Selected;
                return "true";
            }
            catch
            {
                return "false";
            }
        }

        /// <summary>
        ///  Capture element wise screenshots and store it in specified relative path
        /// </summary>
        /// <param name="element"></param>
        /// <returns> returns absolute file path </returns>
        public static string CaptureElementBitMap(IWebElement element)
        {
            var fileName = DateTime.Now.ToString("yyyyMMddHHmmss") + ".png";
            Byte[] screen = ((ITakesScreenshot)DriverContext.Driver).GetScreenshot().AsByteArray;
            Bitmap img = new Bitmap(new System.IO.MemoryStream(screen));
            Rectangle croppedImg = new Rectangle(element.Location.X, element.Location.Y, element.Size.Width, element.Size.Height);
            img = img.Clone(croppedImg, img.PixelFormat);
            img.Save(string.Format(Settings.ReportPath + fileName, ImageFormat.Png));
            return Settings.ReportPath + fileName;
        }
    }


}