using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.IO;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;

namespace csharp_example_task_12
{
    [TestFixture]
    public class Lesson_7
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        [SetUp]
        public void start()
        {
            driver = new FirefoxDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(7);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(7));

        }


        [Test]
        public void FirstTest_Task_13()
        {
            driver.Url = "http://localhost/litecart/";
            //driver.FindElement(By.Name("username")).SendKeys("admin");
            //driver.FindElement(By.Name("password")).SendKeys("admin");
            //driver.FindElement(By.Name("login")).Click();

            Assert.DoesNotThrow(() => driver.FindElement(By.XPath("//h3[contains(.,'Categories')]")));
            driver.FindElement(By.CssSelector("ul.listing-wrapper li.product")).Click();

            Assert.DoesNotThrow(() => driver.FindElement(By.XPath("//h1[contains(.,'Duck')]")));
            var quantityInCart = driver.FindElement(By.CssSelector("div#cart span.quantity"));
            driver.FindElement(By.Name("add_cart_product")).Click();
            wait.Until(ExpectedConditions.StalenessOf(quantityInCart));

            driver.FindElement(By.Id("logotype-wrapper")).Click();

        }
        [TearDown]
        public void stop()
        {
            driver.Quit();
            driver = null;
        }
    }
}
