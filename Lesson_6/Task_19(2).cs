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

namespace csharp_example_task_19
{
    [TestFixture]
    public class Lesson_199
    {
        public IWebDriver driver;
        public WebDriverWait wait;
        [SetUp]
        public void start()
        {
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(2));
        }

        [Test]

        public void FirstTest_Task_19()
        {
            MainPage.MainPageOpen(driver);
            Product.ProductSelectRandom(driver);
            Product.ProductAddInCart(driver, wait);
            MainPage.MainPageOpen(driver);
            Checkout.CheckoutOpen(driver);
            Checkout.CheckoutClean(driver, wait);

        }
        [TearDown]
        public void stop()
        {
            driver.Quit();
            //    driver = null;
        }


    }


    public class Application
    {
        public IWebDriver driver;
        public WebDriverWait wait;
        public Checkout check;

        public Application()
        {
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(2));
            check = new Checkout(this);
        }
    }

    public class Checkout
    {
        private Application app;

        public Checkout(Application paramApp)
        {
            app = paramApp;
        }
        public void CheckoutClean()
        {
            while (app.driver.FindElements(By.Name("remove_cart_item")).Count > 0)
            {
                var duck = app.driver.FindElement(By.Name("remove_cart_item"));
                duck.Click();
                app.wait.Until(ExpectedConditions.StalenessOf(duck));
                Console.WriteLine("товар удален");
            }
            Assert.DoesNotThrow(() => app.driver.FindElement(By.XPath("//p[contains(.,'There are no items in your cart.')]")));
            Console.WriteLine("CheckoutClean");
        }
        public void CheckoutOpen()
        {
            app.driver.Url = "http://localhost/litecart/en/checkout";
            Assert.DoesNotThrow(() => app.driver.FindElement(By.XPath("//div[@id='box-checkout-customer']/h2[contains(.,'Customer Details')]")));
            Console.WriteLine("CheckoutOpen");
        }
    }



    public class Product
    {
        public void ProductAddInCart(IWebDriver driver, WebDriverWait wait)
        {
            //проверяем желтую утку
            if (driver.FindElements(By.Name("options[Size]")).Count != 0)
            {
                var yellowDuckSizes = driver.FindElement(By.Name("options[Size]"));
                var yellowDuckSize = new SelectElement(yellowDuckSizes);
                yellowDuckSize.SelectByValue("Small");
            }
            //добавляем товар
            var quantityInCart = driver.FindElement(By.CssSelector("div#cart span.quantity"));
            var quantityInCartCount = driver.FindElement(By.CssSelector("div#cart span.quantity")).Text;
            driver.FindElement(By.Name("add_cart_product")).Click();
            var quantityInCartNewCounta = Convert.ToInt32(quantityInCartCount) + 1;
            wait.Until(ExpectedConditions.TextToBePresentInElement(quantityInCart, quantityInCartNewCounta.ToString()));
            Console.WriteLine("ProductAddInCart");
        }
        public void ProductSelectRandom(IWebDriver driver)
        {
            driver.FindElement(By.CssSelector("ul.listing-wrapper li.product")).Click();
            Assert.DoesNotThrow(() => driver.FindElement(By.XPath("//h1[contains(.,'Duck')]")));
            Console.WriteLine("ProductSelectRandom");
        }
    }

    public class MainPage
    {
        public void MainPageOpen(IWebDriver driver)
        {
            driver.Url = "http://localhost/litecart/";
            Assert.DoesNotThrow(() => driver.FindElement(By.XPath("//div[@id='box-most-popular']/h3[contains(.,'Most Popular')]")));
            Console.WriteLine("OpenMainPage");
        }
    }
}
