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

namespace csharp_example_task_13
{
    [TestFixture]
    public class Lesson_7
    {
        private IWebDriver driver;
        private WebDriverWait wait;



        [Test]
        public void FirstTest_Task_13()
        {
            driver.Url = "http://localhost/litecart/";
            //driver.FindElement(By.Name("username")).SendKeys("admin");
            //driver.FindElement(By.Name("password")).SendKeys("admin");
            //driver.FindElement(By.Name("login")).Click();

            for (int i = 1; i <= 3; i++)
            {
                Assert.DoesNotThrow(() => driver.FindElement(By.XPath("//div[@id='box-most-popular']/h3[contains(.,'Most Popular')]")));
                driver.FindElement(By.CssSelector("ul.listing-wrapper li.product")).Click();

                Assert.DoesNotThrow(() => driver.FindElement(By.XPath("//h1[contains(.,'Duck')]")));

                //проверяем желтую утку
                if (driver.FindElements(By.Name("options[Size]")).Count != 0)
                {
                    var yellowDuckSizes = driver.FindElement(By.Name("options[Size]"));
                    var yellowDuckSize = new SelectElement(yellowDuckSizes);
                    yellowDuckSize.SelectByValue("Small");
                }
                //получаем количество в товара корзине
                var quantityInCart = driver.FindElement(By.CssSelector("div#cart span.quantity"));
                driver.FindElement(By.Name("add_cart_product")).Click();
                string iString = i.ToString();
                wait.Until(ExpectedConditions.TextToBePresentInElement(quantityInCart, iString));
                var quantityInCartNew = driver.FindElement(By.CssSelector("div#cart span.quantity")).Text;
                driver.FindElement(By.Id("logotype-wrapper")).Click();

            }
            Assert.DoesNotThrow(() => driver.FindElement(By.XPath("//div[@id='box-most-popular']/h3[contains(.,'Most Popular')]")));
            driver.FindElement(By.XPath("//div[@id='cart']/a[contains(.,'Checkout »')]")).Click();

            Assert.DoesNotThrow(() => driver.FindElement(By.XPath("//div[@id='box-checkout-customer']/h2[contains(.,'Customer Details')]")));

            while (driver.FindElements(By.Name("remove_cart_item")).Count >0)
            {
                var duck = driver.FindElement(By.Name("remove_cart_item"));
                duck.Click();
                wait.Until(ExpectedConditions.StalenessOf(duck));

            }
            Assert.DoesNotThrow(() => driver.FindElement(By.XPath("//p[contains(.,'There are no items in your cart.')]")));


        }
        [TearDown]
        public void stop()
        {
            driver.Quit();
            driver = null;
        }


        [SetUp]
        public void start()
        {
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(2));

        }
    }
}
