using NUnit.Framework;
using OpenQA.Selenium;
using Practice.com.generic;
using System;

namespace Practice.com.test
{
    [TestFixture]
   // [Category("Regression")]
    class MyTestCls : MyClass
    {
       
        IWebDriver driver;
        Practice.com.generic.Base obj1 = new Practice.com.generic.Base();
        
        
        public void sample()
        {      
            obj1.closeBrowser();
            addMethod();
                            
        }
                
        [SetUp]
        public void setUp()
        {
            driver=obj1.InitializeBrowser();

        }

        [TearDown]
        public void tearDown()
        {
            obj1.closeBrowser();
        }

        [Test]
        //[Retry(3)]
        [Category("Regression")]
        public void testTitle1()
        {
            driver.Navigate().GoToUrl("http://newtours.demoaut.com/");
            Console.WriteLine(driver.Title);
            
        }

        [TestCase(12, 4, 3)]
        public void AdditionTest(int a, int b, int c)
        {
            Console.WriteLine("Addition is: "+ (a + b + c));
           
        }

        [TestCase(12, 3, 4)]
        [TestCase(12, 2, 6)]
        [TestCase(12, 4, 3)]
        public void DivideTest(int n, int d, int q)
        {
            Assert.AreEqual(q, n / d);
        }

        [TestCase(12, 4, ExpectedResult = 3)]
        public int DivideTest2(int a, int b)
        {
            Console.WriteLine(driver.Title);
            return a / b;
        }

        [TestCase(28, 10, "Dheeren", Author = "DS")]
        public void AuthorTest(int age, int date, String author)
        {
            Console.WriteLine("Name of the author is: " + author +"  "+"Age :" + age +"  " + "Joined on: " + date);
           
        }

        [TestCaseSource("DivideCases")]
        public void TestSourceTest(int n, int d, int q)
        {
            Console.WriteLine("Divident Q:" +" " + q +" " +"Divided n/d:"+ n/d);
            Assert.AreEqual(q, n / d);
        }

        static object[] DivideCases =
        {
        new object[] { 12, 3, 4 },
        new object[] { 12, 2, 6 },
        new object[] { 12, 4, 3 }
       };

        [Test]
        public void AssumeFuncionalityTest()
        {
            String str = "Hello";
            Assume.That(str, Is.EqualTo("Hello"));
            Console.WriteLine("*********AssumeFuncionalityTest is passed**************");
        }

        [Test]
        public void WarnFuncionalityTest()
        {
            Warn.If(2 + 2 != 5);
            Warn.If(() => 2 + 2 != 5);
            Warn.If(2 + 2, Is.Not.EqualTo(5));
            Warn.If(() => 2 + 2, Is.Not.EqualTo(5).After(3000));
            Warn.If(() => 10 + 5, Is.EqualTo(15));
            Assert.Warn("Warning message: It's a warning method");

            Warn.Unless(2 + 2 == 5);

            Console.WriteLine("*********WarnFuncionalityTest is passed**************");
        }

        [Test]
        public void ConstraintTest()
        {
            //Ordered Constraint
            string[] sarray = new string[] { "c", "b", "a" };
            Assert.That(sarray, Is.Ordered.Descending);
        }

        [Test]
        public void ConstraintTest2()
        {
            string[] sarray = new string[] { "d", "a", "b" };
            Assert.That(sarray, Is.Ordered.Ascending);
        }

        [Test]
        public void ConstraintTest3()
        {
            string[] sarray = new string[] { "a", "aa", "aaa" };
            Assert.That(sarray, Is.Ordered.By("Length"));
        }


        [Test]
        public void ConstraintSubSetTest()
        {
            int[] iarray = new int[] { 1, 3 };
            Assert.That(iarray, Is.SubsetOf(new int[] { 1, 2, 3, 4 }));
        }


        [Test]
        public void ConstraintSupersetTest()
        {
            int[] iarray = new int[] { 1, 2, 3 };
            Assert.That(iarray, Is.SupersetOf(new int[] { 1, 3 }));
        }

        [Test]
        public void ConstraintWaitTest()
        {
           var i= Is.True.After(4).PollEvery(500).MilliSeconds;
        }

        [Test]
        public void ConstraintEndsWithTest()
        {
            string phrase = "Make your tests fail before passing!";

            Assert.That(phrase, Does.EndWith("!"));
            Assert.That(phrase, Does.EndWith("PASSING!").IgnoreCase);
        }

        [Test]
        [Ignore("Ignore this")]
        
        public void TestScreenShot()
        {
            driver.Navigate().GoToUrl("http://newtours.demoaut.com/");

            //Screenshot ss = ((ITakesScreenshot)driver).GetScreenshot();

            ITakesScreenshot screenshotDriver = driver as ITakesScreenshot;
            Screenshot screenshot = screenshotDriver.GetScreenshot();

            String fp = "C:\\Users\\6867\\source\\repos\\Practice\\Practice\\Results\\screen" + "_" + DateTime.Now.ToString("dd_MMMM_hh_mm_ss_tt") + ".jpeg";
            screenshot.SaveAsFile(fp, OpenQA.Selenium.ScreenshotImageFormat.Jpeg);

           
        }
    }
}
