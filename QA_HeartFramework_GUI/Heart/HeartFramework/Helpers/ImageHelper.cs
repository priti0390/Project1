using HeartFramework.Base;
using HeartFramework.Config;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeartFramework.Helpers
{
    public static class ImageHelper
    {
        /// <summary>
        /// Pixel by pixel image comparison
        /// </summary>
        /// <param name="baseFile"></param>
        /// <param name="actualFile"></param>
        /// e.g. ImageComparison("\\COI\\Img01.png", WebElementExtension.CaptureElementBitMap(CurrentPage.As<PageClass>().ElementName))
        /// <returns></returns>
        public static bool ImageComparison(string baseFile, string actualFile)
        {
            Boolean result = false;

            Bitmap baseBmp = (Bitmap)Image.FromFile(Environment.CurrentDirectory.ToString() + "\\Data\\" + baseFile);
            Bitmap actualBmp = (Bitmap)Image.FromFile(actualFile);

            if (baseBmp.Size == actualBmp.Size)
            {
                int height = Math.Min(baseBmp.Height, actualBmp.Height);
                int width = Math.Min(baseBmp.Width, actualBmp.Width);

                for (int x = 0; x < width - 1; x++)
                {
                    for (int y = 0; y < height - 1; y++)
                    {
                        if (baseBmp.GetPixel(x, y).A.Equals(actualBmp.GetPixel(x, y).A) &&
                            baseBmp.GetPixel(x, y).B.Equals(actualBmp.GetPixel(x, y).B) &&
                            baseBmp.GetPixel(x, y).G.Equals(actualBmp.GetPixel(x, y).G))
                            result = true;
                        else
                        {
                            result = false;
                            break;
                        }
                    }
                    if (!result)
                        break;
                }

            }
            return result;

        }
    }
}
