using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;

namespace csharp_example_task_8
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
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));

        }

        [Test]
        public void FirstTest_Task_8()
        {
            driver.Url = "http://localhost/litecart/";
            var elements = driver.FindElements(By.CssSelector("div.box#box-most-popular a.link[title*='Blue Duck'] div[class*=sticker]"));
                Assert.AreEqual(1, elements.Count);
            var elements2 = driver.FindElements(By.CssSelector("div.box#box-most-popular a.link[title*='Purple Duck'] div[class*=sticker]"));
                Assert.AreEqual(1, elements2.Count);
            var elements3 = driver.FindElements(By.CssSelector("div.box#box-most-popular a.link[title*='Yellow Duck'] div[class*=sticker]"));
                Assert.AreEqual(1, elements3.Count);
            var elements4 = driver.FindElements(By.CssSelector("div.box#box-most-popular a.link[title*='Green Duck'] div[class*=sticker]"));
                Assert.AreEqual(1, elements4.Count);
            var elements5 = driver.FindElements(By.CssSelector("div.box#box-most-popular a.link[title*='Red Duck'] div[class*=sticker]"));
                Assert.AreEqual(1, elements5.Count);

            var elements6 = driver.FindElements(By.CssSelector("div.box#box-campaigns a.link[title*='Yellow Duck'] div[class*=sticker]"));
            Assert.AreEqual(1, elements3.Count);

            var elements7 = driver.FindElements(By.CssSelector("div.box#box-latest-products a.link[title*='Blue Duck'] div[class*=sticker]"));
            Assert.AreEqual(1, elements.Count);
            var elements8 = driver.FindElements(By.CssSelector("div.box#box-latest-products a.link[title*='Purple Duck'] div[class*=sticker]"));
            Assert.AreEqual(1, elements2.Count);
            var elements9 = driver.FindElements(By.CssSelector("div.box#box-latest-products a.link[title*='Yellow Duck'] div[class*=sticker]"));
            Assert.AreEqual(1, elements3.Count);
            var elements10 = driver.FindElements(By.CssSelector("div.box#box-latest-products a.link[title*='Green Duck'] div[class*=sticker]"));
            Assert.AreEqual(1, elements4.Count);
            var elements11 = driver.FindElements(By.CssSelector("div.box#box-latest-products a.link[title*='Red Duck'] div[class*=sticker]"));
            Assert.AreEqual(1, elements5.Count);
           
        }

        [TearDown]
        public void stop()
        {
            driver.Quit();
            driver = null;
        }
    }
}