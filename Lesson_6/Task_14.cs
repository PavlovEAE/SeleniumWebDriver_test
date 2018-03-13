using System;
using System.Collections.Generic;
using System.Linq;
//using System.IO;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;

namespace csharp_example_task_14
{
    [TestFixture]
    public class Lesson_8
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        [SetUp]
        public void start()
        {
            driver = new InternetExplorerDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(2));
        }

        [Test]
        public void FirstTest_Task_14()
        {
            driver.Url = "http://localhost/litecart/admin/?app=countries&doc=countries";
            driver.FindElement(By.Name("username")).SendKeys("admin");
            driver.FindElement(By.Name("password")).SendKeys("admin");
            driver.FindElement(By.Name("login")).Click();
            Assert.DoesNotThrow(() => driver.FindElement(By.XPath("//h1[contains(.,'Countries')]")));
            driver.FindElement(By.XPath("//a[contains(.,'Add New Country')]")).Click();
            Assert.DoesNotThrow(() => driver.FindElement(By.XPath("//h1[contains(.,'Add New Country')]")));

            var countOutsideLinks = driver.FindElements(By.CssSelector("form[method=post] a[target=_blank]")).Count;
            //запоминаем активное окно
            string mainWindow = driver.CurrentWindowHandle;
            //запоминаем все открытые окна(в данном упражнении не обязательно)
            //надо перегнать коллекцию в стринг
            ICollection<string> existingWindows = driver.WindowHandles;
            var listExistingWindows = existingWindows.ToList();
            for (int i = 0; i < countOutsideLinks; i++)
            {
                //ищем ссылки и выбираем нужную по порядку
                var outsideLink = driver.FindElements(By.CssSelector("form[method=post] a[target=_blank]"));
                outsideLink[i].Click();
                // ждем появления нового окна
                var listNewWindows = new List<String>();
                //ищем идентификатор нового окна
                for (int j = 0; j < 10; j++)
                {
                    ICollection<string> newWindows = driver.WindowHandles;
                    listNewWindows = newWindows.ToList();
                    foreach (var w in existingWindows)
                        listNewWindows.Remove(w);
                    if (listNewWindows.Count > 0)
                        j=9;
                    System.Threading.Thread.Sleep(100);
                }
                Assert.IsTrue(listNewWindows.Count!=0);
                //переключаемся в новое окно
                driver.SwitchTo().Window(listNewWindows[0]);
                // закрываем его
                driver.Close();
                // и возвращаемся в исходное окно
                driver.SwitchTo().Window(mainWindow);
            }
        }
        [TearDown]
        public void stop()
        {
            driver.Quit();
            driver = null;
        }
    }
}
