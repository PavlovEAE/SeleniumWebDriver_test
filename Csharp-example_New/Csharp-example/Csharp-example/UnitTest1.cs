using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;

namespace csharp_example
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
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            //wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            
         
        }

        [Test]
        public void FirstTest()
        {
            driver.Url = "http://localhost/litecart/admin";
         // IWebElement element = wait.Until(d => d.FindElement(By.Name("q")));
            driver.FindElement(By.Name("username")).SendKeys("admin");
            driver.FindElement(By.Name("password")).SendKeys("admin");
            driver.FindElement(By.Name("login")).Click();
            driver.FindElement(By.Id("notices")).Click();
            // wait.Until(ExpectedConditions.TitleIs("webdriverghjghjghjghjfgh - Поиск в Google"));
           // wait.Until(ExpectedConditions.TitleIs("My Store"));
           //IWebElement element = driver.FindElement(By.XPath("//h1[contains(text(),'Template')]"));
            //driver.FindElement(By.Name("login")).Click();
        }

        [TearDown]
        public void stop()
        {
            driver.Quit();
            driver = null;
        }
    }
}