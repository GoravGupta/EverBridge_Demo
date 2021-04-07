using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Configuration;
using SeleniumExtras.PageObjects;
using EBProjectFramework.config;
using EBProjectFramework.Helpers;

namespace EBProjectFramework.baseScripts
{
    public class browserInit : IEnvData
    {
        static IWebDriver driver = null;

        public object ChromePath { get; private set; }

        public void setUpBrowser()
        {
            string URL = "", chromePath = "";
            try
            {
                URL = IEnvData.URL;
                chromePath = IEnvData.CHROME_PATH;
                LogHelper.Write("Opening Browser URL : " + URL);
                driver = new ChromeDriver(chromePath);
                driver.Url = URL;
                driver.Manage().Window.Maximize();
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            }
            catch(Exception e)
            {
                LogHelper.Write(e.Message);
            } 
        }

        public void tearDownBrowser()
        {
            if(driver != null)
            {
                driver.Quit();
            }
        }

        public IWebDriver GetDriver()
        {
            return driver;
        }

    }
}
