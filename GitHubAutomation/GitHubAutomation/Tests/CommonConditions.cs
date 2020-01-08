using System;
using NUnit.Framework;
using OpenQA.Selenium;
using GitHubAutomation.Driver;
using NUnit.Framework.Interfaces;
using GitHubAutomation.Utils;

namespace GitHubAutomation.Tests
{
    public class CommonConditions
    {
        protected IWebDriver Driver;
        protected DateTime now = DateTime.Now;

        [SetUp]
        public void OpenBrowser()
        {
            Driver = DriverSingleton.GetDriver();
        }

        [TearDown]
        public void TearDownTest()
        {
            if (TestContext.CurrentContext.Result.Outcome != ResultState.Success)
            {
                ScreenshotCreater.SaveScreenShot(Driver);
            }

            DriverSingleton.CloseDriver();
        }

    }
}
