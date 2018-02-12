Imports System
Imports NUnit.Framework
Imports NUnit.Framework.Internal
Imports OpenQA.Selenium
Imports OpenQA.Selenium.Chrome
Imports OpenQA.Selenium.IE
Imports OpenQA.Selenium.Support.UI


<TestFixture()>
Public Class MyFirstTest
    Dim _driver As IWebDriver
    Dim _wait As WebDriverWait

    <SetUp()>
    Public Sub Start()
        _driver = New ChromeDriver()
        _wait = New WebDriverWait(_driver, TimeSpan.FromSeconds(10))
    End Sub

    <Test()>
    Public Sub FirstTest()

        _driver.Url = "http://www.google.com/"
        _driver.FindElement(By.Name("q")).SendKeys("webdriver")
        _driver.FindElement(By.Name("btnK")).Click()
        _wait.Until(ExpectedConditions.TitleIs("webdriver - Поиск в Google"))
    End Sub

    <TearDown()>
    Public Sub TearDown()
        _driver.Quit()
        _driver.Dispose()
    End Sub
End Class