using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.com.test.freecrm
{
    class DealPageTest
    {
        IWebDriver driver;
        [SetUp]
        public void setUp()
        {
            driver = new ChromeDriver();

            driver.Manage().Window.Maximize();
            driver.Manage().Cookies.DeleteAllCookies();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);

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
            if (TestContext.CurrentContext.Result.Outcome != ResultState.Success)
            {                
                Screenshot ss = ((ITakesScreenshot)driver).GetScreenshot();

                String testName = TestContext.CurrentContext.Test.Name.ToUpper();

                String fp = "C:\\Users\\6867\\source\\repos\\Practice\\Practice\\Results\\" + testName + "_" + DateTime.Now.ToString("dd_MMMM_hh_mm_ss_tt") + ".png";
                ss.SaveAsFile(fp, OpenQA.Selenium.ScreenshotImageFormat.Png);
            }
            driver.Quit();
        }

        [Test]
        public void newContactFormTest()
        {
            try
            {

                driver.SwitchTo().Frame("mainpanel");

                IWebElement contacts = driver.FindElement(By.XPath("//a[@title='Deals']"));
                Actions action = new Actions(driver);

                action.MoveToElement(contacts).Build().Perform();

                IWebElement newContact = driver.FindElement(By.XPath("//a[@title='New Deal']"));
                newContact.Click();


                IWebElement dealTitle = driver.FindElement(By.XPath("//input[@id='title']"));
                dealTitle.Clear();
                dealTitle.SendKeys("Samsung TV Deal");

                IWebElement client_lookup = driver.FindElement(By.XPath("//input[@name='client_lookup']"));
                client_lookup.Clear();
                client_lookup.SendKeys("Test Solutions");

                IWebElement contact_lookup = driver.FindElement(By.XPath("//input[@name='contact_lookup']"));
                contact_lookup.Clear();
                contact_lookup.SendKeys("Dheerendra Singh");

                IWebElement contactLookup = driver.FindElement(By.XPath("//input[@name='contact_lookup']//following-sibling::input"));
                contactLookup.Click();


                IReadOnlyCollection<String> handles = driver.WindowHandles;

                driver.SwitchTo().Window(handles.Last());

                driver.FindElement(By.XPath("//input[@value='Search' and @type='submit']")).Submit();
                driver.FindElement(By.TagName("a")).Click();



                driver.SwitchTo().Window(handles.First());
                driver.SwitchTo().Frame("mainpanel");

                IWebElement amount = driver.FindElement(By.XPath("//input[@name='amount']"));
                amount.Clear();
                amount.SendKeys("10000");

                IWebElement commission = driver.FindElement(By.XPath("//input[@name='commission']"));
                dealTitle.Clear();
                dealTitle.SendKeys("10");

                SelectElement select = new SelectElement(driver.FindElement(By.Id("product_id")));
                select.SelectByValue("361943");


                IWebElement saveButton = driver.FindElement(By.XPath("//input[@value='Save']"));
                saveButton.Submit();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

    }
}
