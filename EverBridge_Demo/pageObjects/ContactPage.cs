using EBProjectFramework.Helpers;
using OpenQA.Selenium;

using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;

namespace EverBridge_Demo.pageObjects
{
    public class ContactPage
    {

        private IWebDriver driver;
   
        public ContactPage(IWebDriver driver)
        {
            this.driver = driver;
            //This initElements method will create all WebElements
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Id, Using = "id_contact")]
        public IWebElement SubjectHandling { get; set; }

        [FindsBy(How = How.Id, Using = "email")]
        public IWebElement Email { get; set; }

        [FindsBy(How = How.Id, Using = "id_order")]
        public IWebElement Order_Ref { get; set; }

        [FindsBy(How = How.Id, Using = "uniform-fileUpload")]
        public IWebElement FileUpload { get; set; }

        [FindsBy(How = How.Id, Using = "fileUpload")]
        public IWebElement FilePath { get; set; }

        [FindsBy(How = How.Id, Using = "message")]
        public IWebElement MsgBody { get; set; }
        
        [FindsBy(How = How.Id, Using = "submitMessage")]
        public IWebElement Send { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".alert.alert-success")]
        public IWebElement SuccessMsg { get; set; }
        [FindsBy(How = How.CssSelector, Using = ".alert.alert-danger")]
        public IWebElement ErrorMsg { get; set; }

        public void SetSubject()
        {
            SelectElement selectTest = new SelectElement(SubjectHandling);
            //selectTest.SelectByValue(subject);
            selectTest.SelectByIndex(1);

        }
        public void SetEmail(string email)
        {
            Email.Clear();
            Email.SendKeys(email);
        }
        public void SetOrder(string ord)
        {
            Order_Ref.Clear();
            Order_Ref.SendKeys(ord);
        }
        public void SetFile(string filePath)
        {
           // FilePath.SendKeys(filePath);
        }
        public void SetMessage(string msg)
        {
            MsgBody.Clear();
            MsgBody.SendKeys(msg);
        }
        public void SubmitEnquiry()
        {
            Send.Click();
        }

        public string GetMsgText()
        {
            LogHelper.Write("<--GetMsgText()");
            if (SuccessMsg.Displayed) {
                LogHelper.Write("SuccessMsg is Displayed");
                return SuccessMsg.Text;
            }
            else if (ErrorMsg.Displayed) {
                LogHelper.Write("ErrorMsg is Displayed");
                return ErrorMsg.Text;
            }
            else {
                LogHelper.Write("Nothing is Displayed");
                return "";
            }   
        }

        public void FillForm( string email, string ord, string filePath, string msg)
        {
            LogHelper.Write("<--FillForm()");
            this.SetSubject();
            LogHelper.Write("Subject Selected ");
            this.SetEmail(email);
            LogHelper.Write("Email Entered " + email);
            this.SetOrder(ord);
            LogHelper.Write("Order Ref Entered " + ord);
            this.SetFile(filePath);
            LogHelper.Write("File Uploaded " + filePath);
            this.SetMessage(msg);
            LogHelper.Write("Message Entered " + msg);
            this.SubmitEnquiry();
            LogHelper.Write("FillForm()-->");
        }
    }
}
