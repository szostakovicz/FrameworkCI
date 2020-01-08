using OpenQA.Selenium;
using System;
using System.IO;

namespace GitHubAutomation.Utils
{
    public class ScreenshotCreater
    {
        public static void SaveScreenShot(IWebDriver webDriver)
        {
            ITakesScreenshot scrShot = ((ITakesScreenshot)webDriver);
            DirectoryInfo directory = Directory.CreateDirectory(@"Screenshots\" + DateTime.Now.ToString("dd_MM_yyyy") + @"\");
            scrShot.GetScreenshot().SaveAsFile(directory.FullName + @"\" + DateTime.Now.ToString("HH_mm_ss") + ".png", ScreenshotImageFormat.Png);
        }
    }
}
