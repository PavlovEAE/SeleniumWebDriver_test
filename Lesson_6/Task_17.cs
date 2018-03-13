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
        private EventFiringWebDriver driver;
        private WebDriverWait wait;

        [SetUp]
        public void start()
        {
            driver = new EventFiringWebDriver (new ChromeDriver());
            driver.FindingElement += (sender, e)=> Console.WriteLine(e.FindMethod);
            driver.FindElementCompleted += (sender, e) => Console.WriteLine(e.FindMethod + " Found");
            driver.ExceptionThrown += (sender, e) => Console.WriteLine(e.ThrownException);

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(3));

        }

        [Test]
        public void FirstTest_Task_17()
        {
            driver.Url = "http://localhost/litecart/admin/";
            driver.FindElement(By.Name("username")).SendKeys("admin");
            driver.FindElement(By.Name("password")).SendKeys("admin");
            driver.FindElement(By.Name("login")).Click();

            Assert.DoesNotThrow(() => driver.FindElement(By.XPath("//th[contains(.,'Statistics')]")));
            var menus = driver.FindElements(By.Id("app-")).Count;
            //убрать
            driver.FindElement(By.CssSelector("_#app-")).Click();
            Assert.DoesNotThrow(() => driver.FindElement(By.CssSelector("h1")));
            //убрать



            //for (var i = 0; i < menus; i++)
            //{
            //    var selectMenu = driver.FindElements(By.CssSelector("#app-"));
            //    selectMenu[i].Click();

            //    Assert.DoesNotThrow(() => driver.FindElement(By.CssSelector("h1")));

            //    if (driver.FindElements(By.CssSelector("#app-.selected li")).Count > 0)
            //    {
            //        var subMenus = driver.FindElements(By.CssSelector("#app-.selected li")).Count;
            //        for (var j = 0; j < subMenus; j++)
            //        {
            //            var selectSubMenu = driver.FindElements(By.CssSelector("#app-.selected li"));
            //            selectSubMenu[j].Click();
            //            Assert.DoesNotThrow(() => driver.FindElement(By.CssSelector("h1")));
            //        }
            //    }
            //}
        }

        [TearDown]
        public void stop()
        {
            driver.Quit();
            driver = null;
        }
    }
}
