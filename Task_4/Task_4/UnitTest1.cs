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
            driver.Url = "http://localhost/litecart/admin/";
         // IWebElement element = wait.Until(d => d.FindElement(By.Name("q")));
            driver.FindElement(By.Name("username")).SendKeys("admin");
            driver.FindElement(By.Name("password")).SendKeys("admin");
            driver.FindElement(By.Name("login")).Click();
            driver.FindElement(By.Id("notices")).Click();
            // wait.Until(ExpectedConditions.TitleIs("webdriverghjghjghjghjfgh - Поиск в Google"));
            // wait.Until(ExpectedConditions.TitleIs("My Store"));
            
            driver.FindElement(By.XPath("//span[contains(text(),'Appearence')]")).Click();
            IWebElement element = driver.FindElement(By.XPath("//h1[contains(text(),'Template')]"));
            driver.FindElement(By.XPath("//span[contains(text(),'Logotype')]")).Click();
            IWebElement element2 = driver.FindElement(By.XPath("//h1[contains(text(),'Logotype')]"));
            driver.FindElement(By.XPath("//span[contains(text(),'Catalog')]")).Click();
            IWebElement element3 = driver.FindElement(By.XPath("//h1[contains(text(),'Catalog')]"));
            driver.FindElement(By.XPath("//span[contains(text(),'Product Groups')]")).Click();
            IWebElement element4 = driver.FindElement(By.XPath("//h1[contains(text(),'Product Groups')]"));

            driver.FindElement(By.XPath("//span[contains(text(),'Option Groups')]")).Click();
            IWebElement element5 = driver.FindElement(By.XPath("//h1[contains(text(),'Option Groups')]"));
            driver.FindElement(By.XPath("//span[contains(text(),'Manufacturers')]")).Click();
            IWebElement element6 = driver.FindElement(By.XPath("//h1[contains(text(),'Manufacturers')]"));
            driver.FindElement(By.XPath("//span[contains(text(),'Suppliers')]")).Click();
            IWebElement element7 = driver.FindElement(By.XPath("//h1[contains(text(),'Suppliers')]"));
            driver.FindElement(By.XPath("//span[contains(text(),'Delivery Statuses')]")).Click();
            IWebElement element8 = driver.FindElement(By.XPath("//h1[contains(text(),'Delivery Statuses')]"));
            driver.FindElement(By.XPath("//span[contains(text(),'Sold Out Statuses')]")).Click();
            IWebElement element9 = driver.FindElement(By.XPath("//h1[contains(text(),'Sold Out Statuses')]"));
            driver.FindElement(By.XPath("//span[contains(text(),'Quantity Units')]")).Click();
            IWebElement element10 = driver.FindElement(By.XPath("//h1[contains(text(),'Quantity Units')]"));
            driver.FindElement(By.XPath("//span[contains(text(),'CSV Import/Export')]")).Click();
            IWebElement element11 = driver.FindElement(By.XPath("//h1[contains(text(),'CSV Import/Export')]"));
        }

        [TearDown]
        public void stop()
        {
            driver.Quit();
            driver = null;
        }
    }
}