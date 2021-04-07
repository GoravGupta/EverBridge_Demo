using NUnit.Framework;

using OpenQA.Selenium;
using EverBridge_Demo.pageObjects;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using EBProjectFramework.baseScripts;
using EBProjectFramework.Helpers;
using System;
using EverBridge_Demo.configFiles;

namespace EverBridge_Demo.TestCases
{
    public class ContactFormTest : IPaths
    {
        private IWebDriver driver = null;
        readonly FileReaderTxt fileReaderObj = new FileReaderTxt(IPaths.INPUT_FILE_PATH);
        readonly browserInit bInit = new browserInit();

        [SetUp]
        public void SetUp()
        {
            LogHelper.Write("Launching Browser... ");
            bInit.setUpBrowser();
            driver = bInit.GetDriver();
        }
        [Test]
        public void FillForm()
        {
            try {
                ContactPage contactPage = new ContactPage(driver);
                PageFactory.InitElements(driver, contactPage);
                string[] allLines = fileReaderObj.ReadFile();
                //Reading First Line
                string[] data = allLines[0].Split(",");
                string email = data[0], ordRef = data[1], filePath = data[2];
                contactPage.FillForm(email,ordRef,filePath, "User : " + email + " , Order Ref : "+ordRef );
                string msgText = contactPage.GetMsgText();
                Assert.IsTrue(msgText.Contains("Your message has been successfully sent to our team."));
            }
            catch(Exception e) {
                //Taking Screenshot
                takeScreenShot.takeSnapShot();
                Console.WriteLine("Exception in Test");
                LogHelper.Write(e.Message);
                Assert.IsFalse(true);
            }
        }
        
        [TearDown]
        public void TearDown()
        {
           bInit.tearDownBrowser();
        }
    }
}
