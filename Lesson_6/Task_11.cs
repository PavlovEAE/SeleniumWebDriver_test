using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;

using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;

namespace csharp_example_task_11
{
    [TestFixture]
    public class MyTest2
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
        public void FirstTest_Task_11()
        {
            driver.Url = "http://localhost/litecart/";
            driver.FindElement(By.CssSelector("div#box-account-login a")).Click();
            Assert.DoesNotThrow(() => driver.FindElement(By.XPath("//h1[contains(.,'Create Account')]")));
            //driver.FindElement(By.Name("firstname")).SendKeys("First Name");
            //driver.FindElement(By.Name("lastname")).SendKeys("Last Name");
            //driver.FindElement(By.Name("address1")).SendKeys("Address 1");
            //driver.FindElement(By.Name("postcode")).SendKeys("55555");
            //driver.FindElement(By.Name("city")).SendKeys("City");

            driver.FindElement(By.Name("firstname")).SendKeys("F");
            driver.FindElement(By.Name("lastname")).SendKeys("L");
            driver.FindElement(By.Name("address1")).SendKeys("A");
            driver.FindElement(By.Name("postcode")).SendKeys("55555");
            driver.FindElement(By.Name("city")).SendKeys("C");
           
            var elementsCountry = driver.FindElement(By.Name("country_code"));
            
            IJavaScriptExecutor js = driver as IJavaScriptExecutor;
            js.ExecuteScript(@"arguments[0].value = 'US';
                               arguments[0].dispatchEvent(new Event('change'));",
                               elementsCountry);
            //если бы список был видимым
            //var selectCountry = new SelectElement(elementsCountry);
            //selectCountry.SelectByText("United States");
           
            //// создаем уникальную почту
            DateTime Data = DateTime.Now;
            var uniqueEmail = "U" + Data.ToString("yyyyMMddHHmmssms") + "@xmail.ru";
            driver.FindElement(By.Name("email")).SendKeys(uniqueEmail);
            //U201803020614511451@xmail.ru;

            driver.FindElement(By.Name("phone")).SendKeys("8");
            driver.FindElement(By.Name("password")).SendKeys("Qq123");
            driver.FindElement(By.Name("confirmed_password")).SendKeys("Qq123");

            Assert.DoesNotThrow(() => driver.FindElement(By.CssSelector("select[name = zone_code]:not([disabled = disabled])")));
            driver.FindElement(By.Name("create_account")).Click();

            Assert.DoesNotThrow(() => driver.FindElement(By.XPath("//h3[contains(.,'Account')]")));
            driver.FindElement(By.XPath("//div[@id='box-account']//a[contains(.,'Logout')]")).Click();

            Assert.DoesNotThrow(() => driver.FindElement(By.XPath("//h3[contains(.,'Login')]")));
            driver.FindElement(By.Name("email")).SendKeys(uniqueEmail);
            driver.FindElement(By.Name("password")).SendKeys("Qq123");
            driver.FindElement(By.CssSelector("form[name=login_form] button[name=login]")).Click();

            Assert.DoesNotThrow(() => driver.FindElement(By.XPath("//h3[contains(.,'Account')]")));
            driver.FindElement(By.XPath("//div[@id='box-account']//a[contains(.,'Logout')]")).Click();

        }
        [TearDown]
        public void stop()
        {
            driver.Quit();
            driver = null;
        }
    }
}