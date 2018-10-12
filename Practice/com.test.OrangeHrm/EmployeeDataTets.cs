using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.com.test.OrangeHrm
{
    class EmployeeDataTets
    {
        private IWebDriver driver;

        [SetUp]
        public void setUp()
        {
            driver = new ChromeDriver();

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);

            driver.Navigate().GoToUrl("https://opensource-demo.orangehrmlive.com/");
            IWebElement userName = driver.FindElement(By.XPath("//input[@id='txtUsername']"));
            userName.Clear();
            userName.SendKeys("admin");

            IWebElement password = driver.FindElement(By.XPath("//input[@id='txtPassword']"));
            password.Clear();
            password.SendKeys("admin123");

            IWebElement logInButton = driver.FindElement(By.Id("btnLogin"));
            logInButton.Click();

        }

        [Test]
        
        public void employeeListTest()
        {

            WebDriverWait wait = new WebDriverWait(driver, new TimeSpan(20));

            IWebElement pim=driver.FindElement(By.XPath("//a[@id='menu_pim_viewPimModule']"));

            //wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//a[@id='menu_pim_viewPimModule']")));

            //Actions action = new Actions(driver);
            //action.MoveToElement(pim);

            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", pim);



            IWebElement empList = driver.FindElement(By.Id("menu_pim_viewEmployeeList"));
            empList.Click();


            IWebElement config = driver.FindElement(By.Id("menu_pim_Configuration"));
            Actions action1 = new Actions(driver);
            action1.MoveToElement(config);
           
        }

        
    }
}
