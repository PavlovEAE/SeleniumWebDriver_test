using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;

namespace csharp_example_task_12
{
    [TestFixture]
    public class MyTest3
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
        public void FirstTest_Task_12()
        {
            driver.Url = "http://localhost/litecart/admin/";
            driver.FindElement(By.Name("username")).SendKeys("admin");
            driver.FindElement(By.Name("password")).SendKeys("admin");
            driver.FindElement(By.Name("login")).Click();
            driver.FindElement(By.XPath("//ul[@id='box-apps-menu']//span[contains(.,'Catalog')]")).Click();

            Assert.DoesNotThrow(() => driver.FindElement(By.XPath("//h1[contains(.,'Catalog')]")));
            driver.FindElement(By.XPath("//a[@class='button'][contains(.,'Add New Product')]")).Click();

            Assert.DoesNotThrow(() => driver.FindElement(By.XPath("//h1[contains(.,'Add New Product')]")));
            driver.FindElement(By.XPath("//td[contains(.,'Status')]/label[contains(.,'Enabled')]")).Click();
            driver.FindElement(By.XPath("//div[@id='tab-general']//td[contains(.,'Name')]//input")).SendKeys("oldDuck");
            driver.FindElement(By.XPath("//div[@id='tab-general']//td[contains(.,'Code')]//input")).SendKeys("oldDuckCode");
            driver.FindElement(By.XPath("//div[@id='tab-general']//td[contains(.,'Female')]//input[@value='1-2']")).Click();
            driver.FindElement(By.XPath("//div[@id='tab-general']//td[contains(.,'Quantity')]//input")).SendKeys("50,00");
            //загрузка файла
            var _path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"oldDuck.JPG");
            driver.FindElement(By.XPath("//div[@id='tab-general']//td[contains(.,'Upload Images')]//input")).SendKeys(_path);

            driver.FindElement(By.XPath("//div[@id='tab-general']//td[contains(.,'Date Valid From')]//input")).SendKeys(Keys.Home + "01.01.2011");
            driver.FindElement(By.XPath("//div[@id='tab-general']//td[contains(.,'Date Valid From')]//input")).SendKeys(Keys.Home + "01.12.2011");
            driver.FindElement(By.XPath("//ul[@class='index']//a[contains(.,'Information')]")).Click();

            var Manufacturer = driver.FindElement(By.Name("manufacturer_id"));
            IJavaScriptExecutor js = driver as IJavaScriptExecutor;
            js.ExecuteScript(@"arguments[0].value = '1';
                               arguments[0].dispatchEvent(new Event('change'));",
                               Manufacturer);

            driver.FindElement(By.Name("keywords")).SendKeys("Old Duck");
            driver.FindElement(By.Name("short_description[en]")).SendKeys("Old Duck");
            driver.FindElement(By.Name("description[en]")).SendKeys("Very Old Duck");
            driver.FindElement(By.Name("head_title[en]")).SendKeys("head_title Old Duck");
            driver.FindElement(By.Name("meta_description[en]")).SendKeys("meta_description Old Duck");

            driver.FindElement(By.XPath("//ul[@class='index']//a[contains(.,'Prices')]")).Click();
            Assert.DoesNotThrow(() => driver.FindElement(By.XPath("//h2[contains(.,'Prices')]")));
            driver.FindElement(By.Name("purchase_price")).SendKeys(Keys.Home + "10");

            var purchasePriceCode = driver.FindElement(By.Name("purchase_price_currency_code"));
            var selectPurchasePriceCode = new SelectElement(purchasePriceCode);
            selectPurchasePriceCode.SelectByValue("USD");

            driver.FindElement(By.Name("prices[USD]")).SendKeys("55");
            driver.FindElement(By.Name("prices[EUR]")).SendKeys("66");
            driver.FindElement(By.Name("save")).Click();

            Assert.DoesNotThrow(() => driver.FindElement(By.XPath("//h1[contains(.,'Catalog')]")));
            //проверяем что товар добавился в список
            var rows = driver.FindElements(By.CssSelector("form[name=catalog_form] tbody tr.row"));
            var productNames = new List<String>();
            var testComplite = "";
            foreach (var row in rows)
            {
                var productName = row.FindElement(By.XPath(".//td[3]")).Text;
                if (productName == "oldDuck")
                {
                    testComplite = "Тест выполнен-товар добавлен";
                    Console.WriteLine(testComplite);
                }
            }
            Assert.AreEqual(testComplite, "Тест выполнен-товар добавлен");
            
        }
        [TearDown]
        public void stop()
        {
            driver.Quit();
            driver = null;
        }
    }
}