using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.com.test
{
    class MercuryRegisterTest
    {
        IWebDriver driver;
       
        [SetUp]
        public void SetUpBrower()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();

            driver.Navigate().GoToUrl("http://newtours.demoaut.com/");

            driver.Manage().Cookies.DeleteAllCookies();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }

        [Test]
        public void checkTotlaLinksTets()
        {
            ReadOnlyCollection<IWebElement> links =driver.FindElements(By.TagName("a"));

            Console.WriteLine("No. of Links: " + links.LongCount<IWebElement>());
            foreach (IWebElement linksOnPage in links)
            {              
                String textLink = linksOnPage.Text;
                Console.WriteLine("Links:>>>>>>>>>" + textLink);
            }

            //for (int i = 0; i < links.LongCount<IWebElement>(); i++)
            //{
            //    String textLink = links[i].Text;
            //    Console.WriteLine("Links:>>>>>>>>>" + textLink);
            //}
        }

        [Test]
        public void RegisterPageTest()
        {
            //Reach to Registration page
            driver.FindElement(By.PartialLinkText("REGISTER")).Click();

            IWebElement firstname= driver.FindElement(By.XPath("//input[@name='firstName']"));
            firstname.Clear();
            firstname.SendKeys("Dheerendra");

            IWebElement lastname = driver.FindElement(By.Name("lastName"));
            lastname.Clear();
            lastname.SendKeys("Singh");

            IWebElement phone = driver.FindElement(By.XPath("//input[@name='phone']"));
            phone.Clear();
            phone.SendKeys("9766110000");

            IWebElement email = driver.FindElement(By.Id("userName"));
            email.Clear();
            email.SendKeys("dheerendras06@outlook.com");

            IWebElement country = driver.FindElement(By.Name("country"));
            SelectElement select = new SelectElement(country);
            //select.SelectByText("INDIA ");
            select.SelectByValue("92");

            IWebElement username = driver.FindElement(By.Id("email"));
            username.Clear();
            username.SendKeys("seleniumtest");

            IWebElement password = driver.FindElement(By.Name("password"));
            password.Clear();
            password.SendKeys("test@123");

            IWebElement confirmPassword = driver.FindElement(By.Name("confirmPassword"));
            confirmPassword.Clear();
            confirmPassword.SendKeys("test@123");

            IWebElement submitButton = driver.FindElement(By.Name("register"));
            //submitButton.Click();

        }

        
    }
}
