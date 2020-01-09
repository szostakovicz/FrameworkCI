using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using System;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace GitHubAutomation.Driver
{
    public class DriverSingleton
    {
        private static IWebDriver Driver;

        private DriverSingleton() { }

        public static IWebDriver GetDriver()
        {
            if (Driver == null)
            {
                switch (TestContext.Parameters.Get("browser"))
                {
                    case "Edge":
                        new DriverManager().SetUpDriver(new EdgeConfig());
                        Driver = new EdgeDriver();
                        break;
                    default:
                        new DriverManager().SetUpDriver(new ChromeConfig());
                        ChromeOptions options = new ChromeOptions();
                        //options.AddArgument("--user-agent=Mozilla/5.0 (compatible; MJ12bot/v1.4.5; http://www.majestic12.co.uk/bot.php?+)");
                        //Driver = new ChromeDriver(options);

                        Driver = new ChromeDriver();
                        break;
                }
                Driver.Manage().Window.Maximize();
                Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
            }
            return Driver;
        }

        public static void CloseDriver()
        {
            Driver.Quit();
            Driver = null;
        }

    }
}
