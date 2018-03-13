using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.Events;

namespace csharp_example_Task_17
{
    [TestFixture]
    public class MyFirstTest
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        [SetUp]
        public void start()
        {
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(2));
        }
        //{
        //    private EventFiringWebDriver driver;
        //    private WebDriverWait wait;

        //    [SetUp]
        //    public void start()
        //    {
        //        driver = new EventFiringWebDriver (new ChromeDriver());
        //        driver.FindingElement += (sender, e)=> Console.WriteLine(e.FindMethod);
        //        driver.FindElementCompleted += (sender, e) => Console.WriteLine(e.FindMethod + " Found");
        //        driver.ExceptionThrown += (sender, e) => Console.WriteLine(e.ThrownException);

        //        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
        //        wait = new WebDriverWait(driver, TimeSpan.FromSeconds(3));

        //    }

        [Test]
        public void FirstTest_Task_17()
        {
            driver.Url = "http://localhost/litecart/admin/?app=catalog&doc=catalog&category_id=1";
            driver.FindElement(By.Name("username")).SendKeys("admin");
            driver.FindElement(By.Name("password")).SendKeys("admin");
            driver.FindElement(By.Name("login")).Click();


            var setCountProducts = driver.FindElements(By.XPath("//input[starts-with(@name,'products')]/../..//a[not(@title)]")).Count;
            for (int i = 0; i < setCountProducts; i++)
            {
                var selectProducts = driver.FindElements(By.XPath("//input[starts-with(@name,'products')]/../..//a[not(@title)]"));
                selectProducts[i].Click();
                Assert.DoesNotThrow(() => driver.FindElement(By.XPath("//h1[contains(.,'Edit Product:')]")));
                
                if (driver.Manage().Logs.GetLog("browser").Count > 0)
                    foreach (LogEntry l in driver.Manage().Logs.GetLog(LogType.Browser))
                        Console.WriteLine(l);
                else
                    Console.WriteLine("логи пустые,страница в списке = {0}", i);
                Assert.AreEqual(0, driver.Manage().Logs.GetLog("browser").Count);

                driver.Url = "http://localhost/litecart/admin/?app=catalog&doc=catalog&category_id=1";
                Assert.DoesNotThrow(() => driver.FindElement(By.XPath("//h1[contains(.,'Catalog')]")));

            }

        }

        [TearDown]
        public void stop()
        {
            driver.Quit();
            driver = null;
        }
    }
}
