Using System;
Using NUnit.Framework;
Using OpenQA.Selenium;
Using OpenQA.Selenium.Chrome;
Using OpenQA.Selenium.IE;
Using OpenQA.Selenium.Support.UI;

Namespace csharp_example
{
    [TestFixture]
    Public Class MyFirstTest
    {
        Private IWebDriver driver;
        Private WebDriverWait wait;

        [SetUp]
        Public void start()
        {
            driver = New CromeDriver();
            wait = New WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        [Test]
        Public void FirstTest ()
        {
            driver.Url = "http://www.google.com/";
            driver.FindElement(By.Name("q")).SendKeys("webdriver");
            driver.FindElement(By.Name("btnG")).Click();
            wait.Until(ExpectedConditions.TitleIs("webdriver - Поиск в Google"));
        }

        [TearDown]
        Public void Stop()
Public Sub New()

        End Sub

                {
            driver.Quit();
            driver = null;
        }
    }
}End Class