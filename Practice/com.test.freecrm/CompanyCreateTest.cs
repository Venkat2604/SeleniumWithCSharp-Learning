using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.com.test.freecrm
{
    class CompanyCreateTest
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
                //ITakesScreenshot screenshotDriver = driver as ITakesScreenshot;
                //Screenshot ss = screenshotDriver.GetScreenshot();

                Screenshot ss = ((ITakesScreenshot)driver).GetScreenshot();

                String testName = TestContext.CurrentContext.Test.Name;

                String fp = "C:\\Users\\6867\\source\\repos\\Practice\\Practice\\Results\\" + testName + "_" + DateTime.Now.ToString("dd_MMMM_hh_mm_ss_tt") + ".png";
                ss.SaveAsFile(fp, OpenQA.Selenium.ScreenshotImageFormat.Png);                                
            }
            driver.Quit();
        }
        [Test]
        public void newCompanyFormTest()
        {
            try
            {
                driver.SwitchTo().Frame("mainpanel");

                IWebElement companies = driver.FindElement(By.XPath("//a[@title='Companies']"));
                Actions action = new Actions(driver);

                action.MoveToElement(companies).Build().Perform();

                IWebElement newCompany = driver.FindElement(By.XPath("//a[@title='New Company']"));
                newCompany.Click();

                //TakeScreen();



                IWebElement companyName = driver.FindElement(By.Id("company_name"));
                companyName.Clear();
                String company = "Test Solutions";
                companyName.SendKeys(company);

                IWebElement industryType = driver.FindElement(By.Name("industry"));
                industryType.Clear();
                industryType.SendKeys("IT");

                //name = "num_of_employees"
                IWebElement num_of_employees = driver.FindElement(By.Name("num_of_employees"));
                num_of_employees.Clear();
                num_of_employees.SendKeys("707");

                //name= "status"
                IWebElement status = driver.FindElement(By.Name("status"));
                SelectElement statusSelect = new SelectElement(status);
                statusSelect.SelectByValue("Active");


                //address
                IWebElement address = driver.FindElement(By.Name("address"));
                address.Clear();
                address.SendKeys("Pune");

                //city
                IWebElement city = driver.FindElement(By.Name("city"));
                city.Clear();
                city.SendKeys("Pune");

                //name="state"
                IWebElement state = driver.FindElement(By.XPath("//input[@name='state']"));
                state.Clear();
                state.SendKeys("Maharashtra");

                //postcode
                IWebElement postcode = driver.FindElement(By.Name("postcode"));
                postcode.Clear();
                postcode.SendKeys("411057");

                //name="country"
                IWebElement country = driver.FindElement(By.Name("country"));
                country.Clear();
                country.SendKeys("India");

                IWebElement saveButton = driver.FindElement(By.XPath("//input[@type='submit' and @value='Save']"));
                saveButton.Click();


                Assert.AreEqual(company, driver.FindElement(By.XPath("//td[@class='tabs_header']")).Text, "The company is not created and it's not landed on Company details page");

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                TakeScreen();
            }

        }
       
        //[OneTimeTearDown]
        public void TakeScreen()
        {
            
            //if (TestContext.CurrentContext.Result.Outcome != ResultState.Success)
            //{               
                Screenshot ss = ((ITakesScreenshot)driver).GetScreenshot();

                String testName = TestContext.CurrentContext.Test.Name;

                String fp = "C:\\Users\\6867\\source\\repos\\Practice\\Practice\\Results\\" + testName + "_" + DateTime.Now.ToString("dd_MMMM_hh_mm_ss_tt") + ".png";
                ss.SaveAsFile(fp, OpenQA.Selenium.ScreenshotImageFormat.Png);

                //driver.Quit();
            //}

        }

    }
}
