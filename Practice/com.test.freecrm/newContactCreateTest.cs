using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.com.test.freecrm
{
    class newContactCreateTest
    {
        IWebDriver driver;
        [SetUp]
        public void setUp()
        {
            driver = new ChromeDriver();

            driver.Manage().Window.Maximize();           
            driver.Manage().Cookies.DeleteAllCookies();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(40);
            
           // driver.Manage().Timeouts().AsynchronousJavaScript = TimeSpan.FromSeconds(30);

            driver.Navigate().GoToUrl("https://www.freecrm.com/index.html");

            IWebElement username = driver.FindElement(By.XPath("//input[@name='username']"));
            username.Clear();
            username.SendKeys("naveenk");

            IWebElement password = driver.FindElement(By.Name("password"));
            password.Clear();
            password.SendKeys("test@123");

            IWebElement loginButton = driver.FindElement(By.XPath("//input[@value='Login' and @type='submit']"));
            loginButton.Click();
        }
        [TearDown]
        public void tearDown()
        {
            driver.Quit();
        }
        [Test]
        public void newContactFormTest()
        {
            try
            {

                driver.SwitchTo().Frame("mainpanel");

                IWebElement contacts = driver.FindElement(By.XPath("//a[@title='Contacts']"));
                Actions action = new Actions(driver);

                action.MoveToElement(contacts).Build().Perform();

                IWebElement newContact = driver.FindElement(By.XPath("//a[@title='New Contact']"));
                newContact.Click();

                IWebElement firstName = driver.FindElement(By.Id("first_name"));
                firstName.Clear();
                firstName.SendKeys("Dheerendra");

                IWebElement lastName = driver.FindElement(By.Id("surname"));
                lastName.Clear();
                lastName.SendKeys("Singh");

                IWebElement company = driver.FindElement(By.Name("client_lookup"));
                company.Clear();
                company.SendKeys("Test Solution");

                IWebElement companyLookUP = driver.FindElement(By.XPath("//input[@name='client_lookup']//following-sibling::input"));
                companyLookUP.Click();
                IReadOnlyCollection<String> handles = driver.WindowHandles;

                foreach (String noOfwindow in handles)
                {
                    String textLink = noOfwindow;
                    Console.WriteLine("Links:>>>>>>>>>" + textLink);
                }
                Console.WriteLine(handles.Last());
                Console.WriteLine(handles.First());

                driver.SwitchTo().Window(handles.Last());


                driver.FindElement(By.XPath("//input[@value='Search' and @type='submit']")).Submit();
                driver.FindElement(By.TagName("a")).Click();

                driver.SwitchTo().Window(handles.First());
                driver.SwitchTo().Frame("mainpanel");

                driver.FindElement(By.XPath("//input[@value='Save']")).Submit();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        [Test]
        public void contactsTest()
        {
            try
            {

                driver.SwitchTo().Frame("mainpanel");

                IWebElement contacts = driver.FindElement(By.XPath("//a[@title='Contacts']"));
                //Actions action = new Actions(driver);
                //action.MoveToElement(contacts).Build().Perform();
                contacts.Click();

                IWebElement contactPersonName = driver.FindElement(By.Name("cs_name"));
                contactPersonName.Clear();
                contactPersonName.SendKeys("Dheeren");

                IWebElement searchButton = driver.FindElement(By.Name("cs_submit"));
                searchButton.Click();

                //a[contains(text(),'Dheerendra Singh')]

                //form[@id='vContactsForm']//table//tbody//tr[4]//td[1]
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
    }
}
