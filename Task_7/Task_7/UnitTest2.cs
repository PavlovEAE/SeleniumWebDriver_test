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
            driver = new FirefoxDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));

        }

        [Test]
        public void FirstTest()
        {
            driver.Url = "http://localhost/litecart/";
            //эти строкина надо переделать для проверки
            IWebElement element = driver.FindElement(By.CssSelector("div.box#box-most-popular a.link[title*='Red Duck'] div[class*=sticker]"));
            IWebElement element2 = driver.FindElement(By.CssSelector("div.box#box-most-popular a.link[title*='Green Duck'] div[class*=sticker]"));
            IWebElement element3 = driver.FindElement(By.CssSelector("div.box#box-most-popular a.link[title*='Yellow Duck'] div[class*=sticker]"));
            IWebElement element4 = driver.FindElement(By.CssSelector("div.box#box-most-popular a.link[title*='Purple Duck'] div[class*=sticker]"));
            IWebElement element5 = driver.FindElement(By.CssSelector("div.box#box-most-popular a.link[title*='Blue Duck'] div[class*=sticker]"));

              // заготовка       
             //driver.FindElements(By.CssSelector("div.box#box-most-popular a.link[title*='Blue Duck'] div[class*=sticker]"))
            
   

        }

        [TearDown]
        public void stop()
        {
            driver.Quit();
            driver = null;
        }
    }
}