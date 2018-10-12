using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.com.generic
{
    public class Base
    {
        private static IWebDriver driver;
        public  IWebDriver InitializeBrowser()
        {
            driver = new ChromeDriver();

            driver.Manage().Window.Maximize();
            driver.Manage().Cookies.DeleteAllCookies();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);                   

            return driver;
        }

        public void closeBrowser()
        {
            driver.Quit();
           
        }

        public IWebDriver TakeScreen()
        {
            //ITakesScreenshot screenshotDriver = driver as ITakesScreenshot;
            //Screenshot ss = screenshotDriver.GetScreenshot();

            Screenshot ss = ((ITakesScreenshot)driver).GetScreenshot();

            String fp = "C:\\Users\\6867\\source\\repos\\Practice\\Practice\\Results\\screen" + "_" + DateTime.Now.ToString("dd_MMMM_hh_mm_ss_tt") + ".png";
            ss.SaveAsFile(fp, OpenQA.Selenium.ScreenshotImageFormat.Png);
            return driver;
        }


        public void baseMethod1()
        {
          
                Console.Write("In baseMethod");
        }
    }

    class MyClass
    {
        public void addMethod()
        {
            int a = 10;
            int b = 20;
            
            Console.WriteLine("I am from add Method in MyClass: " + " Additions is: "+a + b);
        }

        
    }
}
