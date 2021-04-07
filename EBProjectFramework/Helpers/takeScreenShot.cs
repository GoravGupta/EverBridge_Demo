using EBProjectFramework.baseScripts;
using EBProjectFramework.config;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing.Imaging;

namespace EBProjectFramework.Helpers
{
    public class takeScreenShot : IEnvData
    {
        public static void takeSnapShot()
        {
            IWebDriver driver = new browserInit().GetDriver();
            if(driver == null)
            {
                LogHelper.Write("Driver is Null in takeSnapShot");
            }
            Screenshot ss = ((ITakesScreenshot)driver).GetScreenshot();
            //Save the screenshot
            string cas = "image_"+DateTime.Now.ToString("dd_MM_yy_HH_mm_ss");
            ss.SaveAsFile(IEnvData.SCREENSHOT_FOLDER_PATH+cas+".png", ScreenshotImageFormat.Png);
        }
    }
}
